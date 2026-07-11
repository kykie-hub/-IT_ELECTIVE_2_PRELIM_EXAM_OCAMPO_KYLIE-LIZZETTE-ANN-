namespace IT_ELECTIVE_2_PRELIM_EXAM_HttpClient.Exercises;

// EXERCISE 5: GET Filter by Ingredient
// TheMealDB API: https://themealdb.com/api/json/v1/1/filter.php?i={ingredient}
//
// Your task:
// 1. Use the HttpClient to filter meals by ingredient "chicken_breast"
// 2. Assert status code is 200 OK
// 3. Parse the JSON and assert the "meals" array has at least 1 item
//
// Response format: { "meals": [{ "strMeal": "...", "strMealThumb": "...", "idMeal": "..." }, ...] }

public static class FilterByIngredient
{
    public static async Task Run(System.Net.Http.HttpClient client)
    {
        // TODO: Send GET request to https://themealdb.com/api/json/v1/1/filter.php?i=chicken_breast
        var response = await client.GetAsync("https://themealdb.com/api/json/v1/1/filter.php?i=chicken_breast");

        // TODO: Assert status code is 200 OK
        System.Diagnostics.Debug.Assert(response.StatusCode == System.Net.HttpStatusCode.OK);

        // TODO: Parse the response JSON
        var body = await response.Content.ReadAsStringAsync();
        using var document = System.Text.Json.JsonDocument.Parse(body);

        // TODO: Assert the "meals" array has at least 1 item
        var meals = document.RootElement.GetProperty("meals");
        System.Diagnostics.Debug.Assert(
            meals.ValueKind == System.Text.Json.JsonValueKind.Array &&
            meals.GetArrayLength() > 0
        );
    }
}