#include <iostream>

using namespace std;

int main()
{
    int negativeCount = 0;
    int positiveCount = 0;
    int input;

    cout << "Enter a number: ";
    cin >> input;
    

    while (input != 0)
    {
        if (input < 0)
        {
            negativeCount++;
        }
        else if (input > 0)
        {
            positiveCount++;
        }

        cout << "Enter a number: ";
        cin >> input;
    }

    cout << endl;

    if(negativeCount > positiveCount)
    {
        cout << "Negative";
    }

    else if(negativeCount < positiveCount)
    {
        cout << "Positive";
    }

    else
    {
        cout << "Equal";
    }
}