// wwwroot/js/animations.js
// Animações do site usando GSAP + ScrollTrigger (100% gratuito desde abril/2025).
// Progressive enhancement: se o GSAP não carregar (CDN fora do ar, JS desabilitado),
// o conteúdo continua 100% visível e utilizável — nada depende de JS para aparecer.

(function () {
    "use strict";

    if (typeof gsap === "undefined") return;

    var reduzMovimento = window.matchMedia("(prefers-reduced-motion: reduce)").matches;
    if (reduzMovimento) return; // respeita a preferência do usuário: sem animações

    if (typeof ScrollTrigger !== "undefined") {
        gsap.registerPlugin(ScrollTrigger);
    }

    document.addEventListener("DOMContentLoaded", function () {

        // ===== Hero (Home) — entrada sequencial ao carregar =====
        var hero = document.querySelector(".home-hero");
        if (hero) {
            gsap.from(
                [
                    hero.querySelector(".cursos-eyebrow"),
                    hero.querySelector("h1"),
                    hero.querySelector(".home-hero-texto"),
                    hero.querySelector(".home-hero-cta")
                ].filter(Boolean),
                {
                    opacity: 0,
                    y: 24,
                    duration: 0.7,
                    stagger: 0.12,
                    ease: "power2.out"
                }
            );
        }

        // ===== Linha de rota — desenha ao entrar na tela =====
        var rotaSvg = document.querySelector(".rota-linha svg");
        if (rotaSvg && typeof ScrollTrigger !== "undefined") {
            gsap.fromTo(
                rotaSvg,
                { clipPath: "inset(0 100% 0 0)" },
                {
                    clipPath: "inset(0 0% 0 0)",
                    duration: 1.3,
                    ease: "power2.out",
                    scrollTrigger: {
                        trigger: ".rota-linha",
                        start: "top 80%",
                        once: true
                    }
                }
            );

            var waypoints = rotaSvg.querySelectorAll("circle, text");
            if (waypoints.length) {
                gsap.from(waypoints, {
                    scale: 0,
                    transformOrigin: "center",
                    opacity: 0,
                    duration: 0.45,
                    stagger: 0.12,
                    delay: 0.5,
                    ease: "back.out(1.7)",
                    scrollTrigger: {
                        trigger: ".rota-linha",
                        start: "top 80%",
                        once: true
                    }
                });
            }
        }

        // ===== Faixa de confiança — stagger ao entrar na tela =====
        var confiancaItens = document.querySelectorAll(".confianca-item");
        if (confiancaItens.length && typeof ScrollTrigger !== "undefined") {
            ScrollTrigger.batch(".confianca-item", {
                start: "top 85%",
                once: true,
                onEnter: function (batch) {
                    gsap.from(batch, {
                        opacity: 0,
                        y: 16,
                        duration: 0.5,
                        stagger: 0.1,
                        ease: "power2.out"
                    });
                }
            });
        }

        // ===== Cards de curso (Home) — stagger ao entrar na tela =====
        var cursoCards = document.querySelectorAll(".curso-card");
        if (cursoCards.length && typeof ScrollTrigger !== "undefined") {
            ScrollTrigger.batch(".curso-card", {
                start: "top 88%",
                once: true,
                onEnter: function (batch) {
                    gsap.from(batch, {
                        opacity: 0,
                        y: 20,
                        duration: 0.5,
                        stagger: 0.08,
                        ease: "power2.out"
                    });
                }
            });
        }

        // ===== Timeline de etapas (página de curso) — stagger ao entrar na tela =====
        var etapas = document.querySelectorAll(".curso-box--etapas li");
        if (etapas.length && typeof ScrollTrigger !== "undefined") {
            ScrollTrigger.batch(".curso-box--etapas li", {
                start: "top 90%",
                once: true,
                onEnter: function (batch) {
                    gsap.from(batch, {
                        opacity: 0,
                        x: -16,
                        duration: 0.4,
                        stagger: 0.1,
                        ease: "power2.out"
                    });
                }
            });
        }
    });
})();
