using System.Text;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace UseMe.Pages;

public class IndexModel : PageModel
{
    private readonly ILogger<IndexModel> _logger;


    UnicodeEncoding uni2Encoding = new UnicodeEncoding();
    byte[] thirdString;

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
   

       // UnicodeEncoding uniEncoding = new UnicodeEncoding();

        // Create the data to write to the stream.
        byte[] firstString = uni2Encoding.GetBytes(
            "Invalid file path characters are: ");
        byte[] secondString = uni2Encoding.GetBytes(
            Path.GetInvalidPathChars());

        // int byteCount = thirdString.Count();        

        // using (var reader = new StringReader(manyLines))
        // {
        //     string? item;
        //     do
        //     {
        //         item = reader.ReadLine();
        //         Console.WriteLine(item);
        //     } while (item != null);
        // }

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

            MemoryStream memStream2 = new MemoryStream();

            memStream.CopyTo(memStream2);

            ValidateMe2(memStream2);

            ValidateMe3(memStream);

            Console.WriteLine(
               "Capacity = {0}, Length = {1}, Position = {2}\n",
               memStream.Capacity.ToString(),
               memStream.Length.ToString(),
               memStream.Position.ToString());
        }

        count++;
    }

    bool ValidateMe()
    {
        MemoryStream ms = new MemoryStream(thirdString);
        using (var reader = new BinaryReader(ms))
        {
            var headerBytes = reader.ReadBytes(5);
        }        
        return true;
    }  // end validate
    
    bool ValidateMe2(MemoryStream ms)
    {
        // MemoryStream ms = new MemoryStream(thirdString);
        using (var reader = new BinaryReader(ms))
        {
            var headerBytes = reader.ReadBytes(5);
        }        
        return true;
    }  // end validate

    bool ValidateMe3(MemoryStream ms)
    {
        MemoryStream ms3 = new MemoryStream();

        ms.Position = 0;
        ms.CopyTo(ms3);

        using (var reader = new BinaryReader(ms3))
        {
            var headerBytes = reader.ReadBytes(5);
        }        
        return true;
    }  // end validate
}
