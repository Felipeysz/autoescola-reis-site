// Loading state no botão de envio do formulário de Matrículas
document.addEventListener('DOMContentLoaded', () => {
    const form = document.querySelector('.matriculas-form');
    if (!form) return;

    const botao = form.querySelector('button[type="submit"]');
    if (!botao) return;

    const textoOriginal = botao.textContent;

    form.addEventListener('submit', () => {
        // Se o jQuery Validate estiver carregado e o formulário for inválido,
        // não faz nada — deixa a própria validação mostrar os erros normalmente
        if (window.jQuery && typeof jQuery(form).valid === 'function' && !jQuery(form).valid()) {
            return;
        }

        botao.disabled = true;
        botao.classList.add('btn--carregando');
        botao.textContent = 'Enviando...';
    });
});