public class Solution {
    public class Duo{
        public int value = 0;
        public int index = 0;
        public Duo(int v, int i){
            value = v;
            index = i;
        }
    }
    public int LargestRectangleArea(int[] heights) {
        //stack men behöver ett sätt att lagra värdet och start index
        Stack<Duo> searcher = new Stack<Duo>();
        searcher.Push(new Duo(heights[0],0));
        int maxArea = 0;
        int index = 0;
        for(int i = 1; i<heights.Count();i++){
            index = i;
            while(searcher.Peek().value > heights[i]){

                maxArea = int.Max(maxArea,searcher.Peek().value * (i-searcher.Peek().index));
                index = searcher.Peek().index;
                searcher.Pop();
                if(searcher.Count == 0){
                    break;
                }


            }
            searcher.Push(new Duo(heights[i],index));
            
            
        }
        foreach(Duo x in searcher){
            maxArea = int.Max(maxArea,x.value * (heights.Count()-x.index));
        }
        return maxArea;
    }
}