namespace IT_ELECTIVE_2_PRELIM_EXAM_HttpClient.Exercises;

// EXERCISE 6: POST Create Review
// JSONPlaceholder API: https://jsonplaceholder.typicode.com/posts
//
// Your task:
// 1. Create a JSON body string: { "title": "Great Pasta!", "body": "Loved this recipe", "userId": 1 }
// 2. Wrap it in StringContent with media type "application/json"
// 3. Send a POST request to the URL
// 4. Assert status code is 201 Created
// 5. Parse the response JSON and assert it contains an "id" field
//
// Hint: Use await client.PostAsync(url, content)
// Hint: Use new StringContent(json, Encoding.UTF8, "application/json")

public static class CreateReview
{
    public static async Task Run(System.Net.Http.HttpClient client)
    {
        // TODO: Create JSON string with title, body, and userId
        var json = @"{ ""title"": ""Great Pasta!"", ""body"": ""Loved this recipe"", ""userId"": 1 }";

        // TODO: Create StringContent with the JSON and Content-Type "application/json"
        var content = new System.Net.Http.StringContent(
            json,
            System.Text.Encoding.UTF8,
            "application/json");

        // TODO: Send POST request to https://jsonplaceholder.typicode.com/posts
        var response = await client.PostAsync("https://jsonplaceholder.typicode.com/posts", content);

        // TODO: Assert status code is 201 Created
        System.Diagnostics.Debug.Assert(response.StatusCode == System.Net.HttpStatusCode.Created);

        // TODO: Parse the response JSON
        var body = await response.Content.ReadAsStringAsync();
        using var document = System.Text.Json.JsonDocument.Parse(body);

        // TODO: Assert the response has an "id" field with a value
        System.Diagnostics.Debug.Assert(document.RootElement.TryGetProperty("id", out var id));
        System.Diagnostics.Debug.Assert(id.GetInt32() > 0);
    }
}