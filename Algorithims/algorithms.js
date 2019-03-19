//Given two strings, write a method to decide if one is a permutation of the other.
function isPermutationOf(source, target) {
    if (source.length != target.length) {
        return false;
    }
    var sourceHashTable = {};
    for (var i = 0; i < source.length; i++) {
        if (!sourceHashTable[source[i]]) {
            sourceHashTable[source[i]] = 1;
        } else {
            sourceHashTable[source[i]] = sourceHashTable[source[i]] + 1;
        }
    }

    var targetHashTable = {};
    for (var i = 0; i < target.length; i++) {
        if (!targetHashTable[target[i]]) {
            targetHashTable[target[i]] = 1;
        } else {
            targetHashTable[target[i]] = targetHashTable[target[i]] + 1;
        }
    }
    console.log(sourceHashTable);
    console.log(targetHashTable);
    for (var i = 0; i < source.length; i++) {
        if (sourceHashTable[source[i]] != targetHashTable[source[i]]) {
            return false;
        }
    }
    return true;
}

//Given a string, write a function to check if it is a permutation of a palindrome.
function isPermutationOfAPalindrome(string) {
    var ht = {};
    var oddCount = 0;
    for (var i = 0; i < string.length; i++) {
        var charAti = string[i].toLowerCase();
        if (charAti != ' ') {
            if (!ht[charAti]) {
                ht[charAti] = 1;
                oddCount++;
            } else {
                oddCount -= ht[charAti] % 2;
                ht[charAti] = ht[charAti] + 1;
                oddCount += ht[charAti] % 2;
            }
        }
    }
    console.log(ht);
    console.log(oddCount);
    return oddCount <= 1;
}
$(document).ready(function () {
    var s1 = "TactCooa";
    console.log(s1);
    if (isPermutationOfAPalindrome(s1)) {
        console.log("yes");
    } else {
        console.log("no");
    }
});