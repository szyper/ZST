const routes = {
    "/": "<h1>Strona domowa</h1>",
    "/about": "<h1>Strona informacyjna o mnie</h1>"
};

const navigateTo = (url) => {
    history.pushState(null, null, url);
    router();
};

const router = () => {
    const path = window.location.pathname;
    const view = routes[path] || "<h1>404</h1>";
    document.getElementById('app').innerHTML = view;
};

document.addEventListener("click", e => {
    if (e.target.matches("[data-link]")) {
        e.preventDefault();
        navigateTo(e.target.href);
    }
});

window.addEventListener("popstate", router);

router();