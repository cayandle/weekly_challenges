
const readline = require('readline');
const rl = readline.createInterface({
    input: process.stdin,
    output: process.stdout,
});

rl.question("Please enter the name of an article to generate the hashtags\n", (test) => {
    console.log(getHashTags(test));
    rl.close();
});

function getHashTags(article){
    let first = "";
    let second = "";
    let third = "";
    let words = article.split(" ");
    words.forEach(element => {
        if(element.length>first.length){
            third = second;
            second = first;
            first = element;
        }else if(element.length>second.length){
            third = second;
            second = element;
        }else if(element.length>third.length){
            third = element;
        }
    });
    if(words.length>2){
        return "#"+first.toLowerCase()+", "+"#"+second.toLowerCase()+", "+"#"+third.toLowerCase();
    } else if(words.length==2){
        return "#"+first.toLowerCase()+", "+"#"+second.toLowerCase();
    }
    else if(first==""){
        return "No article title entered";
    }
    else if(words.length==1){
        return "#"+first.toLowerCase();
    }
    else{
        return "No article title entered";
    }
}