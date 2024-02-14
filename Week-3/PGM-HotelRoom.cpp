#include <string>
#include <vector>
#include <queue>
#include <iostream>

using namespace std;

// pair로 만든 priority_queue를 정렬하기
struct compare {
    bool operator()(const pair<int, int>& a, const pair<int, int>& b) const {
        return a.first > b.first;
    }
};

// string말고 int를 쓰자
int strtoint(string time) {
    int result = 0;
    result += (time[0] - '0') * 1000;
    result += (time[1] - '0') * 100;
    result += (time[3] - '0') * 10;
    result += (time[4] - '0');
    return result;
}

// 50분 이상이면 다음 시간으로 바뀜 
int getEndTime(int time) {
    if (time / 10 % 10 == 5) {
        return time + 50;
    }
    else {
        return time + 10;
    }
}

int solution(vector<vector<string>> book_time) {
    // 시작 시간 작은 순으로 times에 보관
    priority_queue<pair<int, int>, vector<pair<int, int>>, compare> times;
    for (auto time : book_time) {
        times.push({ strtoint(time[0]), strtoint(time[1]) });
    }

    // 종료 시간 작은 순으로 rooms에 보관
    priority_queue<int, vector<int>, greater<int>> rooms;
    rooms.push(getEndTime(times.top().second));
    times.pop();
    // 예약 시간을 시작 시간 순으로 보면서, 들어가있는 시간중에 종료 시간이 제일 빠른거를 보면 들어갈수 있는지 없는지 알 수있다.
    while (!times.empty()) {
        int nextRoomStart = times.top().first;
        int nextRoomEnd = times.top().second;
        if (nextRoomStart >= rooms.top()) {
            rooms.pop();
        }
        rooms.push(getEndTime(nextRoomEnd));
        times.pop();
    }
    return rooms.size();
}

