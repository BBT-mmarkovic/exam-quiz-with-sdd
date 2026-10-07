const answerForm = document.querySelector("#answer-form");

if (answerForm) {
    const answerOptions = answerForm.querySelector("#answer-options");
    const submitButton = answerForm.querySelector("#submit-answer");
    const feedback = answerForm.querySelector("#answer-feedback");
    const questionTitle = document.querySelector("#question-title");
    const questionLabel = document.querySelector("#question-label");
    const progressContainer = document.querySelector("#quiz-progress");
    const questionStatus = document.querySelector("#question-status");
    const questionProgress = document.querySelector("#question-progress");
    const questionIndex = answerForm.querySelector("#question-index");
    const resultSummary = document.querySelector("#quiz-result");
    const resultScore = document.querySelector("#quiz-result-score");
    let correctAnswers = 0;
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
            if (result.isCorrect) {
                correctAnswers++;
            }

            if (result.isComplete) {
                answerForm.hidden = true;
                questionTitle.hidden = true;
                questionLabel.hidden = true;
                progressContainer.hidden = true;
                resultScore.textContent = `${correctAnswers} von ${result.totalQuestions} richtig`;
                resultSummary.hidden = false;
                return;
            }

            renderQuestion(result.nextQuestion);
        } catch {
            feedback.textContent = "Die Antwort konnte nicht überprüft werden. Bitte versuche es erneut.";
            answerOptions.disabled = false;
            submitButton.disabled = !answerForm.querySelector('input[name="answer"]:checked');
            isSubmitting = false;
        }
    });

    function renderQuestion(question) {
        questionTitle.textContent = question.text;
        questionIndex.value = question.index;
        questionStatus.textContent = `Frag ${question.index + 1} von ${question.totalQuestions}`;
        questionProgress.max = question.totalQuestions;
        questionProgress.value = question.index + 1;
        answerOptions.disabled = false;
        answerOptions.replaceChildren();

        const legend = document.createElement("legend");
        legend.className = "visually-hidden";
        legend.textContent = "Wähle eine Antwort";
        answerOptions.append(legend);

        question.options.forEach((option, optionIndex) => {
            const inputId = `answer-${question.index}-${optionIndex}`;
            const label = document.createElement("label");
            label.className = "answer-option";
            label.htmlFor = inputId;

            const input = document.createElement("input");
            input.id = inputId;
            input.type = "radio";
            input.name = "answer";
            input.value = option;

            const text = document.createElement("span");
            text.textContent = option;

            label.append(input, text);
            answerOptions.append(label);
        });

        submitButton.disabled = true;
        feedback.textContent = "";
        isSubmitting = false;
    }
}
