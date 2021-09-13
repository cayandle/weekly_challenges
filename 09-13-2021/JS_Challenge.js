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
    for (let i = 0; i < sub.length; i++) {
        for (let j = i; j < sub.length; j++) {
            if(!tempResult.includes(sub[j])){
                tempResult+=sub[j];
            }else{
                break; 
            }
        }
        if(finalResult.length<tempResult.length){
            finalResult=tempResult;
        }
        tempResult=""; 
    }
    return finalResult;
}