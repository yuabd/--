/*
Author:     JBNN
Date:       08-02-15
Use:        These functions and variables are used for the new sliding dropdown menu for All Departments in top menu.
                They are dependant on prototype.js and scriptacoulus.js which should be initialized before this file.
                
Update:     09-01-21
                - Code improvements
                - New function(s) added for simplified left hand navigation
*/

var menuStatus = 'up';  // Parameter to determine whether menu is up or down and is changed when it is completely up/down
var menuPos = 'goUp';           // Parameter to force menu to stay in position on mouseout/mouseover
var toggleId;
var selectedPath = new Array(); 
var activeLinkClass = 'active'; 

/**
*Checks the current link and if it is a guides-link
*/
function checkIfGuidesLink(){
	checkCheckedLink(self.document.location);
}

/*
* If the link is a navigations link from leftNavLinks ad
* it will be selected and the current selection will be
* deselected from the product navigation
*/
function checkCheckedLink(link){
	var hash = link.hash;//self.document.location.hash;
	if(hash == null || '' == hash){
		return;
	}
	var ids = hash.split('-');
	if(ids.length < 2){
		return;
	}
	//Select and expand guides link
	var linkId = 'lnk1.leftnav-'+ids[1]+'-'+ids[2];
	setActiveLink(linkId,true);
	var item = $('lnkSubItemsNavEspot1'+ids[1]);
	toggleBtn(item,$('navToggleNavEspot1'+ids[1]));
	item.show();
	/*Checks if there is a current selected link in the product presentation
	* and de activates it*/
	var len = selectedPath.length;
	for(var i = 0; i < len;i++){
		var obj = selectedPath[i];
		if(!Object.isUndefined(obj.item) && obj.item != null){
			hideMenu($(obj.item),$(obj.btn));
		}else if(!Object.isUndefined(obj.active) && obj.active != null){
			setActiveLink(obj.active,false);		
		}
	}
}

/**
* 
* Activates or de-activates a link in the left navigation
* @param linkId The id of the link that should be (de|)activated 
* @param activate Set to true to activate link, false to deactivate
*/
function setActiveLink(linkId,activate){
	var selectLink = $(linkId);
	var spans = selectLink.getElementsBySelector("span");
	if(spans.length > 0){
		var span = spans[0];
		if(activate){
			span.addClassName(activeLinkClass);
		}else{
			span.removeClassName(activeLinkClass);
		}
			
	}	
}

/**
*
*Adds a container to the selected path
*/
function addContainerToSelectedPath(item,btn){
	selectedPath.push({"item":item,"btn":btn});
}

/**
*KHTJ
* Adds an active link to the selected path
*/
function addLinkToSelectedPath(linkId){
	selectedPath.push({"active":linkId});
}

/**
 * Function(s) for new simplified left hand navigation. Used on category/department pages
 */

function toggleMenuItem(item,btnToggle){
    new Effect.toggle(item, 'slide', {
        delay: 0.3,
        duration:0.6,
        afterFinish: toggleBtn(item, btnToggle)
    });
}

function toggleBtn(menu,btn) {
    if(menu.visible()){
        btn.update("+");
        btn.removeClassName('navToggleOpen');
        btn.next(0).removeClassName('open');
    }else{
        btn.update("&#x2212;");
        btn.addClassName('navToggleOpen');
        btn.next(0).addClassName('open');
    }
}

function hideMenu(item,btn){
    btn.update("+");
    btn.removeClassName('navToggleOpen');
    btn.next(0).removeClassName('open');
   // item.hide();
}

/**
* Functions for All departments dropdown
*/

function callbackDownEnd(obj){
    menuStatus = 'down';
}

function callbackUpEnd(obj){
    menuStatus = 'up';
}

function menuSlideDown(){
    if(($('moreRoomsMenu').getStyle('display') == 'none') && (menuStatus == 'up')){
        // change status to prevent new call until the slide is done
        //trace('sliding down');
        new Effect.SlideDown('moreRoomsMenu', {
            queue: {position: 'end', scope: 'slideDown', limit: 1}, 
            duration: 0.4,
            afterFinish: callbackDownEnd
        });
    }
}

function menuSlideUp(){
    if(($('moreRoomsMenu').getStyle('display') == 'block') && (menuStatus == 'down')){
        // change status to prevent new call until the slide is done
        //trace('sliding up');
        new Effect.SlideUp('moreRoomsMenu', {
            queue: {position: 'end', scope: 'slideUp', limit: 1}, 
            duration: 0.4,
            afterFinish: callbackUpEnd
        });
    }
}

function menuSlideStart(){
    if(menuPos == 'goUp'){
        // If still 0 then no mouseover on menu, so close it
        menuSlideUp();
    }else{
        menuSlideDown();
    }
    return menuPos;
}

function menuToggle(direction){
    clearTimeout(toggleId);
    if(direction == 'down'){
        menuPos = 'goDown';
    }else{
        menuPos = 'goUp';
    }
    toggleId = setTimeout('menuSlideStart()',250);
}

/* Add observers to necessary tags (for drop down menu) */
Event.observe(window, 'load', function() {

    // Add event listener to the div "moreRoomsMenu". This is used to check if user goes from menu button and then over the menu...or just leaves the menu button.
    $('moreRoomsMenu').observe('mouseover', function(event){
        element = Event.element(event);
        myAncestors = element.ancestors();

        // Traverses the parents of current tag
        myAncestors.each(function(tag){
            if(tag.id == 'moreRoomsMenu'){
                menuPos = 'stayDown';
            }
        });
    });

    // Add event listener to the div "moreRoomsMenu". This is used to check if user goes from menu button and then over the menu...or just leaves the menu button.
    $('moreRoomsMenu').observe('mouseout', function(e){
        var element = Event.element(e);
        var inside = false;

        // Get the element we mouse out to
        var goToElement = (e.relatedTarget) ? e.relatedTarget : e.toElement;
        myAncestors = goToElement.ancestors();
 
        // Traverses the parents of the related target (the element that the mouse goes to) and try to find the "moreRoomsMenu"
        myAncestors.each(function(tag){
            if(tag.id == 'moreRoomsMenu'){
                inside = true;
            }
        });
        
        // If inside is false, then we have left the menu...so slide it up
        if(inside == false){
            menuSlideUp();
        }
    });
    
    // Add events to all menu buttons preceeding the moreRooms button, to slide the menu up on mouseover
    var myBtns = $('moreRooms').previousSiblings();
    myBtns.each(function(tag){
        tag.observe('mouseover', function(event){
            menuSlideUp();
        });
    })

    //this should be used as a temporary solution until the left navigation as been implemented in comerce 
    setupSearchMenu();
});

function setupSearchMenu() {
	var searchgroups = $$('.search-groups');
	if (searchgroups.length > 0) {
		try {
			$('minPrice').writeAttribute('style','');
			$('maxPrice').writeAttribute('style','');			
		} catch (err) { }
		var gindex = 1;
		searchgroups[gindex].select('div.header').each(function(obj) {
			if (gindex == 1) gindex = 2;
			var s = obj.readAttribute('onclick');
			var i = s.substring(s.indexOf('(')+2,s.indexOf(')')-1);
			var div = new Element('div', {'class':'contentWrapper'});
			var contentDiv = $('content-' + i);
			contentDiv.childElements().each(function(child) {
				div.insert(child);
			});
			contentDiv.insert(div);
			if (contentDiv.hasClassName('not-displayed')) {
				contentDiv.className = '';
				contentDiv.hide();
			} else {
				obj.addClassName('headerActive');
			}
			obj.writeAttribute('onclick', '');
			if (div.childElements().length == 0) {
				obj.addClassName('headerInactive');
			} else {
				Event.observe(obj, 'click', function(e) {
					this.toggleClassName('headerActive');
					toggleMenuItemSearch(this.next(0));
				});
				Event.observe(obj, 'mouseover', function(e) {
					if (!this.hasClassName('headerHover')) this.addClassName('headerHover');
				});
				Event.observe(obj, 'mouseout', function(e) {
					if (this.hasClassName('headerHover')) this.removeClassName('headerHover');
				});
			}
		});
		/*  IKEA00648492  removed
		var rel = searchgroups[gindex].down('h2');
		rel.addClassName('headerActive');
		rel.writeAttribute('onclick', '');
		Event.observe(rel, 'click', function(e) {
			this.toggleClassName('headerActive');
			toggleMenuItemSearch(this.next(0));
		});
		var div = new Element('div', {'class':'contentWrapper'});
		var contentDiv = $('content-5');
		contentDiv.childElements().each(function(child) {
			div.insert(child);
		});
		contentDiv.insert(div);
		
		*/
	}
}
	
function toggleMenuItemSearch(item) {
    new Effect.toggle(item, 'slide', {
        delay: 0.3,
        duration:0.6
    });
}
