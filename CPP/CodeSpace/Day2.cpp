#include<iostream>
using namespace std;

int main() {
    int q = 0;
    cin >> q;
    int a[100000];

    for (int i = 0; i < q; i++) {
        cin >> a[i];
    }

    for (int i = 0; i < q; i++) {
        if (a[i] == 5 || a[i] == 6) 
            cout << "2300" << endl;
        else 
            cout << "2230" << endl;
    }

    return 0;  
}