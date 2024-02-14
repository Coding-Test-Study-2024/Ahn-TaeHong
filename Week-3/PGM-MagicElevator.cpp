#include <string>
#include <vector>
#include <cmath>

using namespace std;

int solution(int storey) {
    int count = 0;          // count = 필요한 돌 갯수
    int remaining = storey; // remaining = 현제 층

    // 층의 마지막 수를 보면서 올라갈지 내려갈지 결정
    while (remaining > 0) {
        int n = remaining;
        int last = n % 10;  // last = 현제층의 마지막 수
        int e = 0;          // e = 보고있는 수의 10의 e승
        while (last == 0) {   // 층의 마지막 수가 0이면 볼 필요 없음
            n /= 10;
            last = n % 10;
            e++;
        }

        if (last > 5) {       // 수가 5보다 크면 올라가는게 빠르다
            count += 10 - last;
            remaining += (10 - last) * pow(10, e);
        }
        else if (last < 5) {  // 수가 5보다 작으면 내려가는게 빠르다
            count += last;
            remaining -= last * pow(10, e);
        }
        else {               // 수가 5면 앞에있는 수를 보고 결정한다
            if (n / 10 % 10 < 5) { // 수가 5보다 작으면 내려가는게 빠르다
                count += last;
                remaining -= last * pow(10, e);
            }
            else {
                count += last;   // 수가 5보다 크거나 같으면 올라가는게 빠르다
                remaining += last * pow(10, e);
            }
        }
    }

    return count;
}