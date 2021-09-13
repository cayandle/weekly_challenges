
//Create user input on the console for the substring
const readline = require('readline');
const rl = readline.createInterface({
    input: process.stdin,
    output: process.stdout,
});

rl.question("Please enter a string to find the largest substring (Multiple of the same length will just give the first)\n", (test) => {

console.log(longestNonrepeatingSubstring(test));
rl.close();

})


function longestNonrepeatingSubstring(sub){
    let tempResult = "";
    let finalResult = "";

    //First loop to change starting index location
    for (let i = 0; i < sub.length; i++) {
        //Second loop to check through the string starting from the beginning index
        for (let j = i; j < sub.length; j++) {
            //If the temp does not include the character it adds it to the temp string, otherwise it stops the loop
            if(!tempResult.includes(sub[j])){
                tempResult+=sub[j];
            }else{
                break; 
            }
        }
        //At the end of the loop if the result of the inner loop is longer than the current final result the final result will be set equal to the temp result
        if(finalResult.length<tempResult.length){
            finalResult=tempResult;
        }
        //reset the temp result string for the next starting index
        tempResult=""; 
    }
    //return the longest substring
    return finalResult;
}