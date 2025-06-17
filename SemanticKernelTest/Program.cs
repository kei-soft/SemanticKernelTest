using Microsoft.SemanticKernel;
using Microsoft.SemanticKernel.ChatCompletion;

// https://learn.microsoft.com/en-us/semantic-kernel/concepts/ai-services/chat-completion/?tabs=csharp-Ollama%2Cpython-AzureOpenAI%2Cjava-AzureOpenAI&pivots=programming-language-csharp
namespace SemanticKernelTest
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            /* // OpenAI
            var kernel = Kernel.CreateBuilder()
                .AddOpenAIChatCompletion(
                    modelId: "gpt-4o",
                    apiKey: "sk-proj-**")
                .Build();
            */

            // Ollama
#pragma warning disable SKEXP0070
            var builder = Kernel.CreateBuilder();

            string modelId1 = "llama3.2:3b";
            string modelId2 = "benedict/linkbricks-llama3.1-korean:8b";

            builder.AddOllamaChatCompletion(modelId: modelId2, endpoint: new Uri("http://localhost:11434"));

            //using var ollamaClient = new OllamaApiClient(uriString: "http://localhost:11434",defaultModel: "llama3.2:3b");
            //builder.AddOllamaChatCompletion(ollamaClient);


            // Build the kernel
            var kernel = builder.Build();

            //var prompt = "C# Blazor 간단 예제 코딩해줘";
            //var response = await kernel.InvokePromptAsync(prompt);
            //Console.WriteLine(response);

            //response = await kernel.InvokePromptAsync("Login 화면도 만들어줘");
            //Console.WriteLine(response);


            // History
            var chatCompletionService = kernel.GetRequiredService<IChatCompletionService>();
            //IChatCompletionService chatCompletionService = ollamaClient.AsChatCompletionService();

            ChatHistory chatHistory = [];
            // 대화의 전체적인 톤, 규칙, 역할, 스타일 등 LLM의 동작 방식을 지시할 때 사용합니다.
            chatHistory.AddSystemMessage("너는 C# 전문가야");
            // AI(Assistant)가 이전에 했던 답변을 추가합니다.
            chatHistory.AddAssistantMessage("안녕! 무엇을 도와줄까?");
            // 질문
            chatHistory.AddUserMessage("C# Blazor 간단 예제 코딩해줘");

            var response2 = chatCompletionService.GetStreamingChatMessageContentsAsync(chatHistory: chatHistory, kernel: kernel);

            await foreach (var chunk in response2)
            {
                Console.Write(chunk);
            }

            chatHistory.AddUserMessage("Login 화면도 만들어줘");

            response2 = chatCompletionService.GetStreamingChatMessageContentsAsync(chatHistory: chatHistory, kernel: kernel);

            await foreach (var chunk in response2)
            {
                Console.Write(chunk);
            }

            Console.ReadKey();
        }
    }
}
