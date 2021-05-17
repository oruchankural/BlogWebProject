window.onload = registerScripts
window.onpopstate = async function() {
	// load the page into the #main-content
	let content = await require(window.location.href)

	// we'll grab the "#main-content" div content inside the loaded html
	// 1- create a fake html skeleton
	let doc = document.createElement('html');

	// 2- put our loaded content
	doc.innerHTML = content;

	// 3- find "#main-content"
	let mainContent = doc.querySelector('main#main-content')

	// 4- print out for dev purposes
	// console.log(mainContent) 

	// 5- replace current dom
	let currentMainContent = document.querySelector('main#main-content')
	currentMainContent.innerHTML = mainContent.innerHTML

	// 6- change the current "active" navitem (let's ask for help for quick code)
	let active = document.querySelector('nav.nav a.active');
	if( active )
	{
		active.classList.remove('active', 'text-dark', 'border-bottom', 'border-dark')
		active.classList.add('text-muted')
	}

	let navLink = document.querySelector('nav.nav a[href="'+ window.location.href +'"]')
	if( navLink )
	{
		navLink.classList.remove('text-muted')
		navLink.classList.add('active', 'text-dark', 'border-bottom', 'border-dark')
	}

	// 7- register scripts again
	registerScripts()
}

/**
 * Register scripts on each page requests
 */
function registerScripts() {
	registerLinks();
}

/**
 * Register links
 */
function registerLinks() {
	// find all "data-fetcher" links and loop
	document.querySelectorAll('[href]:not([data-unfetch]):not([data-binded])').forEach(function(link) {
		// fix the href attribute
		link.setAttribute('href', link.href)

		// add a click event to load the content
        link.addEventListener('click', async function (event) {
            // mark this link as binded on event:click
            link.dataset.binded = true;

            // don't go anywhere
            event.preventDefault();

            // load the page into the #main-content
            let content = await require(link.href)

            // we'll grab the "#main-content" div content inside the loaded html
            // 1- create a fake html skeleton
            let doc = document.createElement('html');

            // 2- put our loaded content
            doc.innerHTML = content;

            // 3- find "#main-content"
            let mainContent = doc.querySelector('main#main-content')

            // 4- print out for dev purposes
            // console.log(mainContent) 

            // 5- replace current dom
            let currentMainContent = document.querySelector('main#main-content')
            currentMainContent.innerHTML = mainContent.innerHTML

            // 6- change the current "active" navitem (let's ask for help for quick code)

        }

			// 7- register scripts again
			registerScripts()

			// 8- push history
			history.pushState({}, 'Mehmet Girgin\'s Blog', link.href)
		})
	})
}


/**
 * Page loader with 'fetch()'
 */
async function require(pageUrl)
{
	// grab the text-ed version
	return await fetch(pageUrl).then(function(response) { return response.text(); })
}