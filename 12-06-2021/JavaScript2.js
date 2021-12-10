function tune (freq){
    let result = ["-","-","-","-","-","-"];
    for(let i = 0; i < freq.length; i++){
        let accur = freq[i];
        switch (i) {
            case 0:
                result[i]=checker(accur,329.63);
                break;
            case 1:
                result[i]=checker(accur,246.94);
                break;
            case 2:
                result[i]=checker(accur,196.00);
                break;
            case 3:
                result[i]=checker(accur,146.83);
                break;
            case 4:
                result[i]=checker(accur,110.00);
                break;
            case 5:
                result[i]=checker(accur,82.41);
                break;
            default:
                break;
        }
    }
    return result;
}

function checker(current, goal) {
    let test = (current/goal).toFixed(2);
    if(test == 0.00){
        return "-";
    }
    else if(test == 1.00){
        return "OK";
    }
    else if(test > 1.00){
        if(test <= 1.02){
            return "•<";
        }
        else{
            return "•<<";
        }
    }
    else if(test < 1.00){
        if(test >= 0.98){
            return ">•";
        }
        else{
            return ">>•";
        }
    }
}

console.log(tune([0,246.94,0,0,0,80]));
console.log(tune([329,246,195,146,111,82]));
console.log(tune([329.63, 246.94, 196, 146.83, 110, 82.41]));



