using System.Text;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace UseMe.Pages;

public class IndexModel : PageModel
{
    private readonly ILogger<IndexModel> _logger;


    UnicodeEncoding uni2Encoding = new UnicodeEncoding();
    byte[]? thirdString;

    public IndexModel(ILogger<IndexModel> logger)
    {
        _logger = logger;
        thirdString = uni2Encoding.GetBytes(
            "Class level byte array.");
    }

    string manyLines = @"This is line one
        This is line two
        Here is line three
        The penultimate line is line four
        This is the final, fifth line.";

    public void OnGet()
    {
   

        UnicodeEncoding uniEncoding = new UnicodeEncoding();

        // Create the data to write to the stream.
        byte[] firstString = uniEncoding.GetBytes(
            "Invalid file path characters are: ");
        byte[] secondString = uniEncoding.GetBytes(
            Path.GetInvalidPathChars());

        int byteCount = thirdString.Count();
        

        using (var reader = new StringReader(manyLines))
        {
            string? item;
            do
            {
                item = reader.ReadLine();
                Console.WriteLine(item);
            } while (item != null);
        }

        // reader is in scope here, but has been disposed

        int count = 0;


        using (MemoryStream memStream = new MemoryStream(thirdString))
        {
            // Write the stream properties to the console.
            Console.WriteLine(
                "Capacity = {0}, Length = {1}, Position = {2}\n",
                memStream.Capacity.ToString(),
                memStream.Length.ToString(),
                memStream.Position.ToString());


            ValidateMe();

            MemoryStream memStream2 = new MemoryStream(thirdString);

            Console.WriteLine(
               "Capacity = {0}, Length = {1}, Position = {2}\n",
               memStream2.Capacity.ToString(),
               memStream2.Length.ToString(),
               memStream2.Position.ToString());
        }

        count++;
    }

    bool ValidateMe()
    {
        //   UnicodeEncoding uni2Encoding = new UnicodeEncoding();
        //   byte[] thirdString = uni2Encoding.GetBytes(
        //     "Welcome to the Machine");

        MemoryStream ms = new MemoryStream(thirdString);
        using (var reader = new BinaryReader(ms))
        {
            var headerBytes = reader.ReadBytes(5);
        }

        //  using (var reader = new StringReader(manyLines))
        //  {
        //      var headerBytes = reader.ReadLine();

        //  }

        return true;
    }
}
