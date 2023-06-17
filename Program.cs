namespace ConsoleApp6
{
    internal class Program
    {

        class Programi
        {
            static int MergeSort(int[] arr, int[] temp, int left, int right)
            {
                int inversions = 0;

                if (left < right)
                {
                    int mid = (left + right) / 2;
                    inversions += MergeSort(arr, temp, left, mid);
                    inversions += MergeSort(arr, temp, mid + 1, right);
                    inversions += Merge(arr, temp, left, mid + 1, right);
                }

                return inversions;
            }

            static int Merge(int[] arr, int[] temp, int left, int mid, int right)
            {
                int inversions = 0;
                int i = left;
                int j = mid;
                int k = left;

                while (i <= mid - 1 && j <= right)
                {
                    if (arr[i] <= arr[j])
                    {
                        temp[k++] = arr[i++];
                    }
                    else
                    {
                        temp[k++] = arr[j++];
                        inversions += mid - i;
                    }
                }

                while (i <= mid - 1)
                {
                    temp[k++] = arr[i++];
                }

                while (j <= right)
                {
                    temp[k++] = arr[j++];
                }

                for (i = left; i <= right; i++)
                {
                    arr[i] = temp[i];
                }

                return inversions;
            }

            static void Main(string[] args)
            {
                
                string input = Console.ReadLine();
                string[] elements = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);

                int[] arr = new int[elements.Length];
                for (int i = 0; i < elements.Length; i++)
                {
                    arr[i] = int.Parse(elements[i]);
                }

                int[] temp = new int[arr.Length];
                int inversions = MergeSort(arr, temp, 0, arr.Length - 1);

                Console.WriteLine(inversions);
            }

        }
    }
}