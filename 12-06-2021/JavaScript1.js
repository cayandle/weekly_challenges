Math.avg = function (nums, precision) {
    let total = 0;
    nums.forEach(element => {
        total += element;
    });
    let result = total / nums.length;
    if(!precision){
        return result;
    }else{
        return result.toFixed(precision);
    }
    
}

Math.qAvg = function (nums, precision) {
    let total = 0;
    nums.forEach(element => {
        total += (element*element);
    });
    let result = total / nums.length;
    result = Math.pow(result, 1/2);
    if(!precision){
        return result;
    }else{
        return result.toFixed(precision);
    }
}

Math.hAvg = function (nums, precision) {
    let total = 0;
    nums.forEach(element => {
        total += (1/element);
    });
    let result = total / nums.length;
    result = 1/result;
    if(!precision){
        return result;
    }else{
        return result.toFixed(precision);
    }
}

Math.gAvg = function (nums, precision) {
    let total = 1;
    nums.forEach(element => {
        total *= element;
    });
    let result = Math.pow(total, (1/nums.length));
    if(!precision){
        return result;
    }else{
        return result.toFixed(precision);
    }
}

console.log(Math.avg([3,5,7]));
console.log(Math.qAvg([3,5,7],1));
console.log(Math.hAvg([3,5,7],1));
console.log(Math.gAvg([3,5,7],1));