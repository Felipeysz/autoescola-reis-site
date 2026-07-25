// wwwroot/js/site.js
document.addEventListener('DOMContentLoaded', () => {
    const toggle = document.querySelector('.nav-toggle');
    const nav = document.querySelector('.site-nav');

    if (toggle && nav) {
        toggle.addEventListener('click', () => {
            const aberto = nav.classList.toggle('site-nav--aberto');
            toggle.setAttribute('aria-expanded', aberto ? 'true' : 'false');
        });

        // fecha o menu ao clicar em um link
        nav.querySelectorAll('a').forEach(link => {
            link.addEventListener('click', () => {
                nav.classList.remove('site-nav--aberto');
                toggle.setAttribute('aria-expanded', 'false');
            });
        });
    }
});