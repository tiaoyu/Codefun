package main

import (
	"bufio"
	"fmt"
	"os"
	"sort"
	"strings"
)

func CF1935A() {
	in := bufio.NewReader(os.Stdin)
	out := bufio.NewWriter(os.Stdout)
	defer out.Flush()
	var t int
	for fmt.Fscan(in, &t); t > 0; t-- {
		var (
			n int
			s string
		)
		fmt.Fscan(in, &n)
		fmt.Fscan(in, &s)

		l, r, flag := 0, len(s)-1, 0

		for l < r {
			if s[l] == s[r] {
				l++
				r--
				continue
			}
			if s[l] < s[r] {
				flag = -1
				break
			}
			if s[l] > s[r] {
				flag = 1
				break
			}

		}

		if flag == -1 || flag == 0 {
			fmt.Fprintln(out, s)
		} else if flag == 1 {
			var sb strings.Builder
			for i := len(s) - 1; i >= 0; i-- {
				sb.WriteByte(s[i])
			}
			fmt.Fprintln(out, sb.String()+s)
		}
	}

}
func CF1935B() {
	r := NewR(bufio.NewReader(os.Stdin))
	t := r.NextInt()
	for t > 0 {
		t--
		n := r.NextInt()
		l, ll := make([]int, n), make([]int, n)

		for i := 0; i < n; i++ {
			l[i] = r.NextInt()
			ll[i] = l[i]
		}
		sort.Slice(l, func(i, j int) bool {
			return l[i] < l[j]
		})

		a := 0
		for _, v := range l {
			if a == v {
				a++
			}
		}

		if a == 0 {
			fmt.Println(2)
			fmt.Println("1 1")
			fmt.Println("2", n)
		} else {
			ans := make([]struct{ l, r int }, 2)
			ans[0].l = 1
			ans[1].r = 0
			inx := 0
			mm := make(map[int]int, a)
			for i := 0; i < n; i++ {
				if inx > 1 {
					break
				}
				if ll[i] < a {
					mm[ll[i]]++
				}

				if len(mm) == a {
					if inx == 0 {
						ans[0].r = i + 1
					} else {
						ans[1].l = ans[0].r + 1
						ans[1].r = n
					}
					inx++
					mm = make(map[int]int, a)
				}

			}
			if ans[0].l == 0 || ans[0].r == 0 || ans[1].l == 0 || ans[1].r == 0 {
				fmt.Println(-1)
			} else {
				fmt.Println(2)
				fmt.Println(ans[0].l, ans[0].r)
				fmt.Println(ans[1].l, ans[1].r)
			}
		}
	}
}
