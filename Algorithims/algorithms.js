//Given two strings, write a method to decide if one is a permutation of the other.
// time: O(N) space: O(N)
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
// time: O(N) space: O(N) - hashtable
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

//String Compression: Implement a method to perform basic string compression using the counts
//of repeated characters.For example, the string aabcccccaaa would become a2blc5a3.If the
//"compressed" string would not become smaller than the original string, your method should return
//the original string.You can assume the string has only uppercase and lowercase letters(a - z).
// time: O(N)
function compress(str) {
    var count = 1;
    var result = '';
    for (var i = 0; i < str.length; i++) {
        if (i + 1 >= str.length) {
            result += (str[i] + count);
        } else {
            if (str[i] != str[i + 1]) {
                result += (str[i] + count);
                count = 1;
            } else {
                count++;
            }
        }
    }
    return result.length < str.length ? result : str;
}

//Rotate Matrix: Given an image represented by an NxN matrix, where each pixel in the image is 4
//bytes, write a method to rotate the image by 90 degrees.Can you do this in place ?
// time: O(N^2 - always) space: O(n^2)
function rotate(matrix) {
    var column = matrix[0].length;
    var row = matrix.length;
    // create result matrix
    var newMatrix = [];
    for (var r = 0; r < column; r++) {
        newMatrix[r] = [];
    }

    for (var r = 0; r < row; r++) {
        for (var c = 0; c < column; c++) {
            newMatrix[c][row - r - 1] = matrix[r][c];
        }
    }
    return newMatrix;
}

$(document).ready(function () {
    var matrix =
        [[1, 2, 3, 4, 5, 6],
        [2, 3, 4, 5, 6, 7],
        [3, 4, 5, 6, 7, 8],
        [4, 5, 6, 7, 8, 9],
        [5, 6, 7, 8, 9, 10]];
    console.log(matrix);
    var newMatrix = rotate(matrix);
    console.log(newMatrix);
});