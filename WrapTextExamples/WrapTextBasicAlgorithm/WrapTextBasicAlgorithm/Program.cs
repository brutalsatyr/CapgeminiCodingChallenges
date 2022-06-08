
var text = "Bacon ipsum dolor amet pork belly kevin swine picanha flank doner, pancetta shankle corned beef ham hock ham shoulder tail. Beef pork chop andouille ham hock hamburger tongue. Alcatra meatloaf sausage, chislic venison capicola tail sirloin kielbasa bresaola. Turducken corned beef doner brisket cupim biltong Tongue pork belly beef ribs pig, rump jerky meatloaf boudin strip steak ham cow shankle. Pig chicken brisket, alcatra short loin chislic frankfurter jerky shankle tongue kielbasa flank. Buffalo strip steak beef ribs, shank rump flank cow sausage tri-tip landjaeger picanha salami ham hock pig kielbasa. Boudin pancetta biltong ground round cupim. Biltong tongue capicola, strip steak chuck shoulder swine pig. Beef ham landjaeger, boudin kielbasa burgdoggen sausage bresaola alcatra leberkas tenderloin flank ham hock ribeye pig. Leberkas prosciutto tail t-bone shankle cupim. Chuck burgdoggen flank buffalo frankfurter sausage. Tongue doner prosciutto jerky, meatball pancetta kielbasa burgdoggen short ribs turkey salami beef ribs frankfurter ham spare ribs. Rump tri-tip kielbasa porchetta hamburger, jowl pork chuck chislic bresaola. Biltong pastrami meatball cow. Meatball fatback andouille tongue beef ham flank landjaeger chicken turkey drumstick pastrami filet mignon.";
var wordCount = 50;
var words = text.Split(' ');
var lines = words.Skip(1).Aggregate(words.Take(1).ToList(), (line, word) =>
{
    if (line.Last().Length + word.Length >= wordCount)
        line.Add(word);
    else
        line[line.Count - 1] += " " + word;
    return line;
});

foreach(var line in lines)
{
    Console.WriteLine(line);
}

