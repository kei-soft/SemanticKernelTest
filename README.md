# Semantic Kernel - ChatHistory 사용 예제

🔗 **관련 블로그 포스팅**: [https://keistory.tistory.com/1741](https://keistory.tistory.com/1741)

이 프로젝트는 [Microsoft Semantic Kernel](https://github.com/microsoft/semantic-kernel)의 `ChatHistory` 기능을 활용하여, 대화형 문맥을 유지하는 간단한 챗봇 예제입니다.

## 📘 소개

Semantic Kernel에서의 `ChatHistory`는 사용자, AI, 시스템 메시지를 순차적으로 저장하여 LLM이 대화 문맥을 이해하고 자연스럽게 응답할 수 있도록 합니다. 이 저장 기능을 활용하면, AI가 이전 대화 내용을 기억하여 일관성 있는 응답을 제공할 수 있습니다.

---

## 📁 프로젝트 구성

- `Program.cs`  
  Semantic Kernel의 `Kernel`, `IChatCompletionService`, `ChatHistory`를 활용한 대화 예제

---

## 💬 실행 예시

```csharp
chatHistory.AddUserMessage("오늘 날씨 어때?");
var reply = await chatService.GetChatMessageContentAsync(chatHistory);
chatHistory.AddAssistantMessage(reply.Content);

chatHistory.AddUserMessage("그럼 우산 챙겨야 할까?");
