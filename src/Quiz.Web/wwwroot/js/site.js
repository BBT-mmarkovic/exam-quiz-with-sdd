const answerForm = document.querySelector("#answer-form");

if (answerForm) {
    const answerOptions = answerForm.querySelector("#answer-options");
    const submitButton = answerForm.querySelector("#submit-answer");
    const feedback = answerForm.querySelector("#answer-feedback");
    const radios = answerForm.querySelectorAll('input[name="answer"]');
    let isSubmitting = false;

    answerForm.addEventListener("change", () => {
        submitButton.disabled = !answerForm.querySelector('input[name="answer"]:checked');
    });

    answerForm.addEventListener("submit", async (event) => {
        event.preventDefault();

        if (isSubmitting || submitButton.disabled) {
            return;
        }

        const requestBody = new URLSearchParams(new FormData(answerForm));
        isSubmitting = true;
        submitButton.disabled = true;
        answerOptions.disabled = true;
        feedback.textContent = "";

        try {
            const response = await fetch(answerForm.action, {
                method: "POST",
                headers: { "Content-Type": "application/x-www-form-urlencoded; charset=UTF-8" },
                body: requestBody,
                credentials: "same-origin"
            });

            if (!response.ok) {
                throw new Error("Die Antwort konnte nicht überprüft werden.");
            }

            const result = await response.json();
            feedback.textContent = result.message;

            for (const radio of radios) {
                if (radio.value === result.correctAnswer) {
                    radio.closest(".answer-option").classList.add("is-correct");
                }
            }
        } catch {
            feedback.textContent = "Die Antwort konnte nicht überprüft werden. Bitte versuche es erneut.";
            answerOptions.disabled = false;
            submitButton.disabled = !answerForm.querySelector('input[name="answer"]:checked');
            isSubmitting = false;
            return;
        }

        isSubmitting = false;
    });
}
