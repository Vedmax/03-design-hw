#define _CRT_SECURE_NO_WARNINGS
#include <iostream>
#include <vector>
#include <cstdio>
#include <algorithm>
#include <cmath>
#include <cassert>
using namespace std;

const int INF = (int)1e9;
const int N = 1000;

int n;
int s, t;
int c[N][N];
int f[N][N];
bool used[N];

int dfs(int v, int flow)
{
	used[v] = true;
	if (v == t || flow == 0)
		return flow;

	for (int to = 0; to < n; to++)
	{
		int can = c[v][to] - f[v][to];
		if (used[to] || can == 0)
			continue;
		int push = dfs(to, min(flow, can));
		if (push == 0)
			continue;
		f[v][to] += push;
		f[to][v] -= push;
		return push;
	}

	return 0;
}

int main()
{
	freopen("in.txt", "r", stdin);
	freopen("out.txt", "w", stdout);

	scanf("%d", &n);
	for (int i = 0; i < n; i++)
		for (int j = 0; j < n; j++)
			scanf("%d", &c[i][j]);
	//1-indexing?
	scanf("%d%d", &s, &t);
	s--;
	t--;

	assert(s != t);

	int ans = 0;
	while (true)
	{
		fill(used, used + N, false);
		int add = dfs(s, INF);
		if (add == 0)
			break;
		ans += add;
	}

	printf("%d", ans);

	return 0;
}
