namespace IT_ELECTIVE_2_PRELIM_EXAM_HttpClient.Exercises;

// EXERCISE 10: GET Deserialize Multiple Meals
// TheMealDB API: https://themealdb.com/api/json/v1/1/search.php?f=a
//
// This endpoint returns ALL meals starting with the letter "a".
//
// Your task:
// 1. Use the HttpClient to fetch meals starting with letter "a"
// 2. Assert status code is 200 OK
// 3. Parse the JSON and get the "meals" array
// 4. Assert the array has more than 0 items
// 5. Loop through each meal and print its name (strMeal)
//
// Response format:
// {
//   "meals": [
//     { "idMeal": "52772", "strMeal": "Arrabiata", ... },
//     { "idMeal": "52781", "strMeal": "Ayam Percik", ... },
//     ...
//   ]
// }

public static class DeserializeMeals
{
    public static async Task Run(System.Net.Http.HttpClient client)
    {
        // TODO: Send GET request to https://themealdb.com/api/json/v1/1/search.php?f=a
        var response = await client.GetAsync("https://themealdb.com/api/json/v1/1/search.php?f=a");

        // TODO: Assert status code is 200 OK
        System.Diagnostics.Debug.Assert(response.StatusCode == System.Net.HttpStatusCode.OK);

        // TODO: Parse the response JSON
        var body = await response.Content.ReadAsStringAsync();
        using var document = System.Text.Json.JsonDocument.Parse(body);

        // TODO: Get the "meals" array
        var meals = document.RootElement.GetProperty("meals");

        // TODO: Assert the array has more than 0 items
        System.Diagnostics.Debug.Assert(
            meals.ValueKind == System.Text.Json.JsonValueKind.Array &&
            meals.GetArrayLength() > 0);

        // TODO: Loop through and print each meal's strMeal
        foreach (var meal in meals.EnumerateArray())
        {
            Console.WriteLine(meal.GetProperty("strMeal").GetString());
        }
    }
}