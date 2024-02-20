package main

import (
	"bufio"
	"fmt"
	"os"
	"sort"
)

func CF1918A() {
	r := NewR(bufio.NewReader(os.Stdin))
	t := r.NextInt()
	for t > 0 {
		t--
		n, m := r.NextInt(), r.NextInt()

		x := m / 2
		fmt.Println(x * n)
	}
}
func CF1918B() {
	r := NewR(bufio.NewReader(os.Stdin))
	t := r.NextInt()
	for t > 0 {
		t--
		n := r.NextInt()
		l := make([]struct{ a, b int }, n)
		for i := 0; i < n; i++ {
			l[i] = struct{ a, b int }{a: r.NextInt()}
		}
		for i := 0; i < n; i++ {
			l[i].b = r.NextInt()
		}

		sort.Slice(l, func(i, j int) bool {
			return l[i].a+l[i].b < l[j].a+l[j].b
		})

		fmt.Print(l[0].a)
		for i := 1; i < n; i++ {
			fmt.Print(" ", l[i].a)
		}
		fmt.Println()

		fmt.Print(l[0].b)
		for i := 1; i < n; i++ {
			fmt.Print(" ", l[i].b)
		}
		fmt.Println()
	}
}

// a b 转为 二进制
// 找到ab间最高一位不相等的位，然后从这位的后一位开始计算，用 xor 与 a 运算尽可能转为0，与 b 运算尽可能转为1，这样保证a和b的差值最小
// 调换 a b的值，再计算一次
// 取 两者间最小值即为结果
func CF1918C() {
	r := NewR(bufio.NewReader(os.Stdin))
	t := r.NextInt()
	for t > 0 {
		t--
		A, B, R := r.NextInt(), r.NextInt(), r.NextInt()

		f := func(a, b int) int {
			aa, bb := a, b
			sA, sB := make([]int, 64), make([]int, 64)
			inx := 63
			for aa > 0 || bb > 0 {
				sA[inx] = aa & 1
				sB[inx] = bb & 1
				aa >>= 1
				bb >>= 1
				inx--
			}

			sA = sA[inx+1:]
			sB = sB[inx+1:]

			var ans int
			first := false
			for i := 0; i < len(sA); i++ {
				if sA[i] == sB[i] {
					continue
				}
				if !first && sA[i] != sB[i] {
					first = true
					continue
				}
				if first {
					if sA[i] == 1 {
						tmp := 1 << (len(sA) - i - 1)
						if ans+tmp <= R {
							ans += tmp
						}
					}
				}
			}
			ans = (a ^ ans) - (b ^ ans)
			if ans < 0 {
				ans = -ans
			}
			return ans
		}
		aa := f(A, B)
		bb := f(B, A)
		if aa < bb {
			fmt.Println(aa)
		} else {
			fmt.Println(bb)
		}
	}
}
