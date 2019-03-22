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

//Given a directed graph, design an algorithm to find out whether there is a
//route between two nodes.
function hasPath(sourceNode, destNode) {
    if (sourceNode.value == destNode.value) {
        return true;
    }
    if (!sourceNode.children) {
        return false;
    }
    for (var i = 0; i < sourceNode.children.length; i++) {
        if (hasPath(sourceNode.children[i], destNode)) {
            return true;
        }
    }
    return false;
}
$(document).ready(function () {
    var n0 = { value: 0 };
    var n1 = { value: 1 };
    var n2 = { value: 2 };
    var n3 = { value: 3 };
    var n4 = { value: 4 };
    var n5 = { value: 5 };

    n0.children = [n1,n4,n5];
    n1.children = [n3, n4];
    n2.children = [n1];
    n3.children = [n2, n4];

    var graph = [
        n0,
        n1,
        n2,
        n3,
        n4,
        n5,
    ];
    var findItemInGraph = function(value) {
        for (var i = 0; i < graph.length; i++) {
            if (graph[i].value == value) {
                return graph[i];
            }
        }
        return undefined;
    }
    var src = findItemInGraph(0);
    var dst = findItemInGraph(3);
    var connected = hasPath(src, dst) || hasPath(dst, src);
    if (connected) {
        console.log('yes');
    } else {
        console.log('no');
    }
});