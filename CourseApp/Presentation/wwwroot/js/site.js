function addCookie(key, value, days) {
    var date = new Date();
    date.setTime(date.getTime() + (days * 24 * 60 * 60 * 1000));
    document.cookie = `${key}=${value};expires=${date.toUTCString()};path=/`;
}
function toggleTheme() {
    var element = document.body;
    element.dataset.bsTheme =
        element.dataset.bsTheme == "light" ? "dark" : "light";
}