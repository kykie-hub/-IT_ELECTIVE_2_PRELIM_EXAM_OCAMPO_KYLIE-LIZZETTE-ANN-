namespace IT_ELECTIVE_2_PRELIM_EXAM_HttpClient.Exercises;

// EXERCISE 4: GET List Categories
// TheMealDB API: https://themealdb.com/api/json/v1/1/categories.php
//
// Your task:
// 1. Use the HttpClient to fetch all meal categories
// 2. Assert status code is 200 OK
// 3. Parse the JSON and assert the "categories" array has more than 0 items
//
// Response format: { "categories": [{ "strCategory": "Beef", ... }, ...] }

public static class GetCategories
{
    public static async Task Run(System.Net.Http.HttpClient client)
    {
        // TODO: Send GET request to https://themealdb.com/api/json/v1/1/categories.php
        var response = await client.GetAsync("https://themealdb.com/api/json/v1/1/categories.php");

        // TODO: Assert status code is 200 OK
        System.Diagnostics.Debug.Assert(response.StatusCode == System.Net.HttpStatusCode.OK);

        // TODO: Parse the response JSON
        var body = await response.Content.ReadAsStringAsync();
        using var document = System.Text.Json.JsonDocument.Parse(body);

        // TODO: Assert the "categories" array has more than 0 items
        var categories = document.RootElement.GetProperty("categories");
        System.Diagnostics.Debug.Assert(
            categories.ValueKind == System.Text.Json.JsonValueKind.Array &&
            categories.GetArrayLength() > 0
        );
    }
}