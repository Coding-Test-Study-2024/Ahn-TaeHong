#include <string>
#include <iostream>
#include <vector>
#include <algorithm>
#include <map>

using namespace std;

map<string, int> candidates;  // 조합 후보와 갯수 보관
int highests[11] = {};        // 코스 메뉴 갯수에 따라 가장 큰 주문 갯수 보관

// 재귀로 코스 조합 찾기
void find_candidates(int cur_idx, string cur_str, int len, string order) {
    if (cur_idx == order.length()) {
        return;
    }
    if (cur_str.length() == len) {
        candidates[cur_str]++;
        if (candidates[cur_str] > highests[len]) {
            highests[len] = candidates[cur_str];
        }
        return;
    }
    for (int i = cur_idx + 1; i < order.length(); i++) {
        find_candidates(i, cur_str + order[i], len, order);
    }
}

vector<string> solution(vector<string> orders, vector<int> course) {
    vector<string> courses;

    // 원하는 메뉴 갯수별로 조합 찾기
    for (int target_len : course) {
        for (string order : orders) {
            sort(order.begin(), order.end());
            for (int i = 0; i < order.length(); i++) {
                find_candidates(i, string(1, order[i]), target_len, order);
            }
        }
    }

    // 찾은 조합중에 가장 높은 조합 찾기
    for (auto cand : candidates) {
        if (cand.second < 2) {    // 2명 이하면 필요없음
            continue;
        }
        if (cand.second == highests[cand.first.length()]) {
            courses.push_back(cand.first);
        }
    }

    return courses;
}

