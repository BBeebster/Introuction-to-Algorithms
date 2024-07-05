using System.Data;
using System.Globalization;

namespace Chapter2;

class Program
{
    static void Main(string[] args)
    {
        //initialize an array
        int[] array = {1, 4, 6, 9, 2, 4, 5, 7};

        //run and test insertionSort
        Console.WriteLine("insertionSort:");
        insertionSort(array, array.Length);
        for (int i = 0; i < array.Length; i++) {
            Console.Write(array[i]);
            if (i != array.Length - 1) {
                Console.Write(", ");
            }
        }
        Console.WriteLine("");
        

        //run and test reverseInsertionSort
        Console.WriteLine("reverseInsertionSort:");
        reverseInsertionSort(array, array.Length);
        for (int i = 0; i < array.Length; i++) {
            Console.Write(array[i]);
            if (i != array.Length - 1) {
                Console.Write(", ");
            }
        }
        Console.WriteLine("");
    

        //running and testing linearSearch
        Console.WriteLine("linearSearch:");
        int x = 19;
        Console.WriteLine($"{x} occurs at indicy; {lineaerSearch(array, array.Length, x)}, in the array.");
        Console.WriteLine();
        

        //running and testing addBinaryArrays
        Console.WriteLine("addBinaryArrays:");
        int[] A = {0, 1, 1, 0, 1};
        int[] B = {0, 0, 1, 1, 1};
        int[] C = addBinaryArrays(A, B, A.Length);
        for (int i = 0; i < C.Length; i++) {
            Console.Write(C[i]);
            if (i != C.Length - 1) {
                Console.Write(", ");
            }
        }
        Console.WriteLine("");
    

        //run and test selectionSort
        Console.WriteLine("selectionSort:");
        selectionSort(array, array.Length);
        for (int i = 0; i < array.Length; i++) {
            Console.Write(array[i]);
            if (i != array.Length - 1) {
                Console.Write(", ");
            }
        }
        Console.WriteLine("");

        //run and test mergeSort
        Console.WriteLine("mergeSort: ");
        mergeSort(array, 0, array.Length-1);
        for (int i = 0; i < array.Length; i++) {
            Console.Write(array[i]);
            if (i != array.Length - 1) {
                Console.Write(", ");
            }
        }
        Console.WriteLine("");

        //run and test recursiveInsertionSort
        Console.WriteLine("recrusiveInsertionSort: ");
        recursiveInsertionSort(array, array.Length);
        for (int i = 0; i < array.Length; i++) {
            Console.Write(array[i]);
            if (i != array.Length - 1) {
                Console.Write(", ");
            }
        }
        Console.WriteLine("");

        Console.WriteLine($"{binarySearchRecursive(array, 0, array.Length, 8)}");
        Console.WriteLine($"{binarySearchIterative(array, 8)}");
    }

    static void insertionSort(int[] array, int length) {
        for (int i = 1; i < length; i++) {
            int key = array[i];
            int j = i -1;
            while (j >= 0 && array[j] > key) {
                array[j+1] = array[j];
                j--;
                array[j+1] = key;
            }
        }
        return;
    }
    
    static void reverseInsertionSort(int[] array, int length) {
        for (int i = 1; i < length; i++) {
            int key = array[i];
            int j = i - 1;
            while (j >= 0 && array[j] < key) {
                array[j+1] = array[j];
                j--;
                array[j+1] = key;
            }
        }
        return;
    }

    static int lineaerSearch(int[] array, int length, int x) {
        int i = 0;
        while (i < length) {
            if (array[i] == x) {
                return i;
            }
            i++;
        }
        Console.WriteLine($"{x} does not appear in the array.");
        return -1;
    }
    static int[] addBinaryArrays(int[] A, int[] B, int length) {
        int[] C = new int[length];
        int carry = 0;
        for (int i = length-1; i >= 0; i--) {
            int x = A[i] + B[i] + carry;
            C[i] = x % 2;
            if (x == 2 || x == 3) {
                carry = 1; 
            } else {
                carry = 0;
            }
        }
        return C;
    }

    static void selectionSort(int[] array, int length) {
        for (int i = 0; i < length; i++) {
            int key = array[i];
            int smallest = i;
            for (int j = i; j < length; j++) {
                if (array[j] < array[i]) {
                    array[i] = array[j];
                    smallest = j;
                }
            }
            array[smallest] = key;
        }
        return;
    }

    //this method assumes both halves are already sorted
    static int[] merge(int[] array, int left, int middle, int right) {
        int i, j;
        int leftLength = middle - left + 1;
        int rightLength = right - middle;
        int[] leftArray = new int[leftLength];
        int[] rightArray = new int[rightLength];
        //fill leftArray
        for (i = 0; i < leftLength; i++) {
            leftArray[i] = array[left + i];
        }
        //fill rightArray
        for (j = 0; j < rightLength; j++) {
            rightArray[j] = array[middle + j + 1];
        }
        i = 0;
        j = 0;
        int k = left;

        while(i < leftLength && j < rightLength) {
            if (leftArray[i] <= rightArray[j]) {
                array[k] = leftArray[i];
                i++;
            } else {
                array[k] = rightArray[j];
                j++;
            }
            k++;
        }

        while (i < leftLength) {
            array[k] = leftArray[i];
            i++;
            k++;
        }
        while (j < rightLength) {
            array[k] = rightArray[j];
            j++;
            k++;
        }
        return array;
    }

    //this method does not make the above assumptions

    static void mergeSort(int[] array, int left, int right) {
        if (left < right) {
            int middle = left + (right - left)/2;
            mergeSort(array, left, middle);
            mergeSort(array, middle+1, right);
            merge(array, left, middle, right);
        }
        return;
    }

    static void recursiveInsertionSort(int[] array, int length) {
        if (length <= 1) {
            return;
        }

        recursiveInsertionSort(array, length-1);
        
        int last = array[length - 1];
        int j = length - 2;

        while (j >=0 && array[j] > last) {
            array[j+1] = array[j];
            j--;
        }
        array[j+1] = last;
    }

    static object binarySearchRecursive(int[] array, int right, int left, int search) {
        if (right > left) {
            Console.WriteLine($"{search} was not found in the array");
            return "Null";
        } else {
            int middle = (left+right)/2;
            if (search == array[middle]) {
                return middle;
            } else if (search < array[middle]) {
                return binarySearchRecursive(array, right, middle-1, search);
            } else {
                return binarySearchRecursive(array, middle+1, left, search);
            }
        }
    }

    static object binarySearchIterative(int[] array, int search) {
        int right = 0;
        int left = array.Length-1;
        while (right <= left) {
            int middle = (right+left)/2;
            if (search == array[middle]) {
                return middle;
            } else if (search < array[middle]) {
                left = middle-1;
            } else {
                right = middle+1;
            }
        }
        return "Null";
    }
    
}
