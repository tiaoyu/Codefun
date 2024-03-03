package main

import (
	"bufio"
	"fmt"
	"os"
	"sort"
)

func CF1934A() {
	r := NewR(bufio.NewReader(os.Stdin))
	t := r.NextInt()
	for t > 0 {
		t--
		n := r.NextInt()
		l := make([]int, n)
		for i := 0; i < n; i++ {
			l[i] = r.NextInt()
		}
		sort.Slice(l, func(i int, j int) bool {
			return l[i] < l[j]
		})
		a1 := l[n-1] - l[0]
		a2 := l[0] - l[n-2]
		a3 := l[n-2] - l[1]
		a4 := l[1] - l[n-1]

		if a1 < 0 {
			a1 = -a1
		}
		if a2 < 0 {
			a2 = -a2
		}
		if a3 < 0 {
			a3 = -a3
		}
		if a4 < 0 {
			a4 = -a4
		}
		fmt.Println(a1 + a2 + a3 + a4)
	}
}
func CF1934B() {
	model := []int{15, 10, 6, 3, 1}
	tt := map[int]map[int]int{
		15: {1: 1, 2: 2, 3: 1, 4: 2, 5: 1, 6: 1, 7: 2, 8: 2, 9: 2, 10: 1, 11: 2, 12: 2, 13: 2, 14: 3},
		10: {1: 1, 2: 1, 3: 1, 4: 2},
		6:  {1: 1, 2: 2, 3: 1},
		3:  {1: 1, 2: 2},
	}
	r := NewR(bufio.NewReader(os.Stdin))
	t := r.NextInt()
	for t > 0 {
		t--
		n := r.NextInt()
		ans := 0
		for i := 0; i < 5; i++ {
			if n < model[i] {
				continue
			}
			x := n / model[i]
			y := n % model[i]
			if x > 0 {
				ans += x
			}
			if y > 0 {
				if x > 0 {
					ans += tt[model[i]][y]
					break
				} else {
					n = y
				}
			} else {
				break
			}
		}
		fmt.Println(ans)
	}
}
func CF1934C() { // NO
	in := bufio.NewReader(os.Stdin)
	out := bufio.NewWriter(os.Stdout)
	defer out.Flush()
	var t int
	for fmt.Fscan(in, &t); t > 0; t-- {
		var n, m int
		fmt.Fscan(in, &n)
		fmt.Fscan(in, &m)
		fmt.Fprintln(out, "?", 1, 1)
		out.Flush()
		var a, b, c int
		flag := false
		fmt.Fscan(in, &a)
		if a == 0 {
			fmt.Fprintln(out, "! 1 1")
			out.Flush()
			flag = true
		} else {
			fmt.Fprintln(out, "?", n, 1)
			fmt.Fscan(in, &b)
			if b == 0 {
				fmt.Fprintln(out, "!", n, 1)
				out.Flush()
				flag = true
			} else {
				fmt.Fprintln(out, "?", n, m)
				fmt.Fscan(in, &c)
				if c == 0 {
					fmt.Fprintln(out, "!", n, m)
					out.Flush()
					flag = true
				}
			}
		}
		if !flag {

		}
	}
}
