function countBoomerangs(numbers){
    let count = 0;
    for(let i = 1; i < numbers.length-1; i++){
        if(numbers[i-1]==numbers[i+1]&&numbers[i]!=numbers[i-1]){
            count++;
        }
    }
    return count;
}

function countLoneOnes(number){
    let numberString = String(number);
    let count = 0;
    for(let i = 0; i < numberString.length; i++){
        if(numberString.length == 1){
            if(numberString[i]=='1'){
                count++;
            }
        }
        else if(i == 0){
            if(numberString[i]=='1'&&numberString[i+1]!='1'){
                count++;
            }
        }else if(i == numberString.length-1){
            if(numberString[i]=='1'&&numberString[i-1]!='1'){
                count++;
            }
        }else{
            if(numberString[i]=='1'&&numberString[i-1]!='1'&&numberString[i+1]!='1'){
                count++;
            }
        }
    }
    return count;
}

console.log(countBoomerangs([9, 5, 9, 5, 1, 1, 1]));
console.log(countBoomerangs([5, 6, 6, 7, 6, 3, 9]));
console.log(countBoomerangs([4, 4, 4, 9, 9, 9, 9]));
console.log(countLoneOnes(101));
console.log(countLoneOnes(1191));
console.log(countLoneOnes(1111));
console.log(countLoneOnes(462));