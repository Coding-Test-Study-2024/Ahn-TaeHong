#include <string>
#include <vector>
#include <queue>
#include <iostream>

using namespace std;

// pair�� ���� priority_queue�� �����ϱ�
struct compare {
    bool operator()(const pair<int, int>& a, const pair<int, int>& b) const {
        return a.first > b.first;
    }
};

// string���� int�� ����
int strtoint(string time) {
    int result = 0;
    result += (time[0] - '0') * 1000;
    result += (time[1] - '0') * 100;
    result += (time[3] - '0') * 10;
    result += (time[4] - '0');
    return result;
}

// 50�� �̻��̸� ���� �ð����� �ٲ� 
int getEndTime(int time) {
    if (time / 10 % 10 == 5) {
        return time + 50;
    }
    else {
        return time + 10;
    }
}

int solution(vector<vector<string>> book_time) {
    // ���� �ð� ���� ������ times�� ����
    priority_queue<pair<int, int>, vector<pair<int, int>>, compare> times;
    for (auto time : book_time) {
        times.push({ strtoint(time[0]), strtoint(time[1]) });
    }

    // ���� �ð� ���� ������ rooms�� ����
    priority_queue<int, vector<int>, greater<int>> rooms;
    rooms.push(getEndTime(times.top().second));
    times.pop();
    // ���� �ð��� ���� �ð� ������ ���鼭, ���ִ� �ð��߿� ���� �ð��� ���� �����Ÿ� ���� ���� �ִ��� ������ �� ���ִ�.
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

