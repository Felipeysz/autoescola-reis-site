// wwwroot/js/animations.js
// Animações do site usando GSAP + ScrollTrigger (100% gratuito desde abril/2025).
// Progressive enhancement: se o GSAP não carregar (CDN fora do ar, JS desabilitado),
// o conteúdo continua 100% visível e utilizável — nada depende de JS para aparecer.
//
// Responsividade: usamos gsap.matchMedia() para ter DOIS comportamentos distintos,
// não a mesma animação "desligada pela metade" no mobile:
//   - Desktop/tablet (>= 769px): animações completas, incluindo o SVG da linha de rota.
//   - Mobile (<= 768px): versões mais curtas e leves. A linha de rota SVG é ignorada
//     aqui de propósito, porque o CSS responsivo já esconde esse elemento
//     (display: none) nesse breakpoint — animar algo invisível é desperdício de CPU.

(function () {
    "use strict";

    if (typeof gsap === "undefined") return;

    var reduzMovimento = window.matchMedia("(prefers-reduced-motion: reduce)").matches;
    if (reduzMovimento) return; // respeita a preferência do usuário: sem animações

    if (typeof ScrollTrigger !== "undefined") {
        gsap.registerPlugin(ScrollTrigger);
    }

    document.addEventListener("DOMContentLoaded", function () {

        var mm = gsap.matchMedia();

        // =====================================================================
        // DESKTOP / TABLET (>= 769px) — animações completas
        // =====================================================================
        mm.add("(min-width: 769px)", function () {

            // ----- Hero (Home) — entrada sequencial ao carregar -----
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

            // ----- Linha de rota (SVG) — só existe visualmente no desktop -----
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

            // ----- Faixa de confiança -----
            if (document.querySelectorAll(".confianca-item").length && typeof ScrollTrigger !== "undefined") {
                ScrollTrigger.batch(".confianca-item", {
                    start: "top 85%",
                    once: true,
                    onEnter: function (batch) {
                        gsap.from(batch, { opacity: 0, y: 16, duration: 0.5, stagger: 0.1, ease: "power2.out" });
                    }
                });
            }

            // ----- Cards de curso (Home) -----
            if (document.querySelectorAll(".curso-card").length && typeof ScrollTrigger !== "undefined") {
                ScrollTrigger.batch(".curso-card", {
                    start: "top 88%",
                    once: true,
                    onEnter: function (batch) {
                        gsap.from(batch, { opacity: 0, y: 20, duration: 0.5, stagger: 0.08, ease: "power2.out" });
                    }
                });
            }

            // ----- Página de curso (Detalhe) — entrada sequencial -----
            var cursoHero = document.querySelector(".curso-hero");
            if (cursoHero) {
                gsap.from(
                    [cursoHero.querySelector("h1"), cursoHero.querySelector(".curso-subtitulo")].filter(Boolean),
                    { opacity: 0, y: 20, duration: 0.6, stagger: 0.1, ease: "power2.out" }
                );

                var badgeGrande = document.querySelector(".curso-badge-grande");
                var introducao = document.querySelector(".curso-introducao");
                gsap.from([badgeGrande, introducao].filter(Boolean), {
                    opacity: 0, y: 16, duration: 0.5, stagger: 0.1, delay: 0.3, ease: "power2.out"
                });

                var ctaLateral = document.querySelector(".curso-cta");
                if (ctaLateral) {
                    gsap.from(ctaLateral, { opacity: 0, x: 24, duration: 0.6, delay: 0.35, ease: "power2.out" });
                }
            }

            // ----- Boxes da página de curso -----
            if (document.querySelectorAll(".curso-box").length && typeof ScrollTrigger !== "undefined") {
                ScrollTrigger.batch(".curso-box", {
                    start: "top 88%",
                    once: true,
                    onEnter: function (batch) {
                        gsap.from(batch, { opacity: 0, y: 20, duration: 0.5, stagger: 0.12, ease: "power2.out" });
                    }
                });
            }

            // ----- Timeline de etapas -----
            if (document.querySelectorAll(".curso-box--etapas li").length && typeof ScrollTrigger !== "undefined") {
                ScrollTrigger.batch(".curso-box--etapas li", {
                    start: "top 90%",
                    once: true,
                    onEnter: function (batch) {
                        gsap.from(batch, { opacity: 0, x: -16, duration: 0.4, stagger: 0.1, ease: "power2.out" });
                    }
                });
            }

            // gsap.matchMedia limpa tudo isso sozinho se a tela cruzar o breakpoint
            // (ex: usuário gira o tablet ou redimensiona a janela) — não precisa
            // de cleanup manual aqui.
        });

        // =====================================================================
        // MOBILE (<= 768px) — versões leves: menos distância, menos stagger,
        // sem clip-path scroll-linked (mais caro pra thread principal em
        // aparelhos mais fracos), e SEM animar a linha de rota (está oculta).
        // =====================================================================
        mm.add("(max-width: 768px)", function () {

            // ----- Hero (Home) — fade simples, sem deslocamento grande -----
            var hero = document.querySelector(".home-hero");
            if (hero) {
                gsap.from(
                    [
                        hero.querySelector(".cursos-eyebrow"),
                        hero.querySelector("h1"),
                        hero.querySelector(".home-hero-texto"),
                        hero.querySelector(".home-hero-cta")
                    ].filter(Boolean),
                    { opacity: 0, y: 10, duration: 0.4, stagger: 0.08, ease: "power1.out" }
                );
            }

            // ----- Cards de curso — stagger mais curto -----
            if (document.querySelectorAll(".curso-card").length && typeof ScrollTrigger !== "undefined") {
                ScrollTrigger.batch(".curso-card", {
                    start: "top 92%",
                    once: true,
                    onEnter: function (batch) {
                        gsap.from(batch, { opacity: 0, y: 10, duration: 0.35, stagger: 0.06, ease: "power1.out" });
                    }
                });
            }

            // ----- Página de curso — só o essencial (badge + título), sem
            // animar o CTA lateral em x (no mobile ele já está reordenado
            // pro topo via CSS, então deslocar no eixo X não faz sentido) -----
            var cursoHero = document.querySelector(".curso-hero");
            if (cursoHero) {
                gsap.from(
                    [cursoHero.querySelector("h1"), cursoHero.querySelector(".curso-subtitulo")].filter(Boolean),
                    { opacity: 0, y: 10, duration: 0.4, stagger: 0.06, ease: "power1.out" }
                );
            }

            // ----- Boxes da página de curso — fade simples -----
            if (document.querySelectorAll(".curso-box").length && typeof ScrollTrigger !== "undefined") {
                ScrollTrigger.batch(".curso-box", {
                    start: "top 92%",
                    once: true,
                    onEnter: function (batch) {
                        gsap.from(batch, { opacity: 0, y: 10, duration: 0.35, stagger: 0.08, ease: "power1.out" });
                    }
                });
            }

            // ----- Timeline de etapas — sem deslocamento lateral (a timeline
            // já ocupa quase toda a largura em telas pequenas) -----
            if (document.querySelectorAll(".curso-box--etapas li").length && typeof ScrollTrigger !== "undefined") {
                ScrollTrigger.batch(".curso-box--etapas li", {
                    start: "top 94%",
                    once: true,
                    onEnter: function (batch) {
                        gsap.from(batch, { opacity: 0, duration: 0.3, stagger: 0.06, ease: "power1.out" });
                    }
                });
            }

            // Faixa de confiança: no mobile, deixamos aparecer direto sem
            // animação — normalmente já está perto do topo da dobra e o
            // fade competiria com o fade do hero.
        });

        // =====================================================================
        // Independe de breakpoint: botão do WhatsApp
        // =====================================================================
        var whatsappBtn = document.querySelector(".whatsapp-float");
        if (whatsappBtn) {
            var ehTelaPequena = window.matchMedia("(max-width: 768px)").matches;
            var suportaHover = window.matchMedia("(hover: hover)").matches;

            gsap.fromTo(
                whatsappBtn,
                { scale: 0, opacity: 0 },
                {
                    scale: 1,
                    opacity: 1,
                    duration: 0.5,
                    delay: ehTelaPequena ? 0.6 : 1.1, // aparece mais rápido no mobile
                    ease: "back.out(1.7)",
                    onComplete: function () {
                        // Respiração contínua: só no desktop. Em mobile isso roda
                        // pra sempre em background e gasta bateria sem ninguém
                        // "passar o mouse" pra perceber o efeito de qualquer forma.
                        if (!ehTelaPequena) {
                            gsap.to(whatsappBtn, {
                                scale: 1.06,
                                duration: 1.4,
                                ease: "sine.inOut",
                                yoyo: true,
                                repeat: -1
                            });
                        }
                    }
                }
            );

            // Hover só faz sentido em dispositivos que de fato têm hover
            // (mouse) — em touch isso evita comportamento estranho de "hover
            // preso" depois de um toque.
            if (suportaHover) {
                whatsappBtn.addEventListener("mouseenter", function () {
                    gsap.killTweensOf(whatsappBtn);
                    gsap.to(whatsappBtn, { scale: 1.1, duration: 0.2, ease: "power1.out" });
                });
                whatsappBtn.addEventListener("mouseleave", function () {
                    gsap.to(whatsappBtn, {
                        scale: 1,
                        duration: 0.2,
                        ease: "power1.out",
                        onComplete: function () {
                            if (!ehTelaPequena) {
                                gsap.to(whatsappBtn, {
                                    scale: 1.06,
                                    duration: 1.4,
                                    ease: "sine.inOut",
                                    yoyo: true,
                                    repeat: -1
                                });
                            }
                        }
                    });
                });
            }
        }
    });
})();