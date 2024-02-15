package main

import (
	"bufio"
	"fmt"
	"os"
	"sort"
	"strconv"
	"strings"
)

type R struct {
	sc        *bufio.Reader
	split     []string
	index     int
	separator string
}

func (in *R) GetLine() string {
	line, err := in.sc.ReadString('\n')
	if err != nil {
		fmt.Println("error line:", line, " err: ", err)
	}
	in.split = []string{}
	in.index = 0
	return line
}
func (in *R) load() {
	if len(in.split) <= in.index {
		in.split = strings.Split(in.GetLine(), in.separator)
		in.index = 0
	}
}

func (in *R) NextInt() int {
	in.load()
	val, _ := strconv.Atoi(strings.TrimSpace(in.split[in.index]))
	in.index++
	return val
}

func (in *R) NextInt64() int64 {
	in.load()
	val, _ := strconv.ParseInt(strings.TrimSpace(in.split[in.index]), 10, 64)
	in.index++
	return val
}
func NewR(r *bufio.Reader) *R {
	return &R{
		sc:        r,
		split:     []string{},
		index:     0,
		separator: " ",
	}
}
func (in *R) NextString() string {
	in.load()
	val := strings.TrimSpace(in.split[in.index])
	in.index++
	return val
}

func main() {
	CF1928B()
}

func CF1928B() {
	r := NewR(bufio.NewReader(os.Stdin))
	t := r.NextInt()
	for t > 0 {
		t--
		n := r.NextInt()
		l := make([]int, n)
		for i := 0; i < n; i++ {
			l[i] = r.NextInt()
		}
		sort.Slice(l, func(i, j int) bool {
			return l[i] < l[j]
		})
		max, ans := 1, 1
		left, right := 0, 0
		for left < n && right < n {
			if left == right {
				right++
				ans = 1
				continue
			}

			if l[left] == l[right] {
				left++
				right++
				continue
			}

			if l[right] == l[right-1] {
				right++
				continue
			}

			if left+1 < n && l[left+1] == l[left] {
				left++
				continue
			}

			if l[right]-l[left] < n {
				ans++
				if ans > max {
					max = ans
				}
				right++
			} else {
				left++
				ans--
			}
		}

		fmt.Println(max)
	}
}

func CF1928A() {
	r := NewR(bufio.NewReader(os.Stdin))
	t := r.NextInt()
	for t > 0 {
		t--
		a, b := r.NextInt(), r.NextInt()
		if a&1 == 1 && b&1 == 1 {
			fmt.Println("NO")
		} else if a&1 == 1 && b&1 == 0 {
			if a+a == b {
				fmt.Println("NO")
			} else {
				fmt.Println("YES")
			}
		} else if a&1 == 0 && b&1 == 1 {
			if a == b+b {
				fmt.Println("NO")
			} else {
				fmt.Println("YES")
			}
		} else {
			fmt.Println("YES")
		}
	}
}

func CF1927E() {
	r := NewR(bufio.NewReader(os.Stdin))
	t := r.NextInt()
	for t > 0 {
		t--
		n, k := r.NextInt(), r.NextInt()
		s := n / k
		m := n % k
		if m > 0 {
			s++
		}
		ans := make([]int, n)
		tmp := -1
		max := 0
		current := max
		up := false
		for i := 0; i < k; i++ {
			up = !up
			tmp *= -1
			if up {
				current = max + 1
			} else {
				current = max + s
			}

			for j := 0; j < s; j++ {
				ans[j*k+i] = current + tmp*j
				if ans[j*k+i] > max {
					max = ans[j*k+i]
				}
			}
			m--
			if m == 0 {
				s--
			}
		}
		fmt.Print(ans[0])
		for i := 1; i < n; i++ {
			fmt.Print(" ", ans[i])
		}
		fmt.Println()
	}
}

func CF1927D() {
	r := NewR(bufio.NewReader(os.Stdin))
	t := r.NextInt()
	for t > 0 {
		t--
		n := r.NextInt()
		l := make([]int, n)
		for i := 0; i < n; i++ {
			l[i] = r.NextInt()
		}
		next := make(map[int]int)
		for i := n - 1; i >= 0; i-- {
			if i == n-1 {
				next[i] = n
			} else {
				if l[i] == l[i+1] {
					next[i] = next[i+1]
				} else {
					next[i] = i + 1
				}
			}
		}
		q := r.NextInt()
		for i := 0; i < q; i++ {
			a, b := r.NextInt()-1, r.NextInt()-1
			if a == b {
				fmt.Println("-1 -1")
			} else {
				if a > b {
					a, b = b, a
				}
				if next[a] == 0 || next[a] > b {
					fmt.Println("-1 -1")
				} else {
					fmt.Println(a+1, next[a]+1)
				}
			}
		}
	}
}

func CF1927C() {
	r := NewR(bufio.NewReader(os.Stdin))
	t := r.NextInt()
	for t > 0 {
		t--
		n := r.NextInt()
		m := r.NextInt()
		k := r.NextInt()
		l := make(map[int32]struct{})
		rr := make(map[int32]struct{})
		for i := 0; i < n; i++ {
			tmp := r.NextInt()
			if tmp > k {
				continue
			}
			l[int32(tmp)] = struct{}{}
		}
		for i := 0; i < m; i++ {
			tmp := r.NextInt()
			if tmp > k {
				continue
			}
			rr[int32(tmp)] = struct{}{}
		}
		if len(l) < (k/2) || len(rr) < (k/2) {
			fmt.Println("NO")
		} else {
			for k := range l {
				rr[k] = struct{}{}
			}
			if len(rr) != k {
				fmt.Println("NO")
			} else {
				fmt.Println("YES")
			}
		}
	}
}

func CF1927B() {
	r := NewR(bufio.NewReader(os.Stdin))
	t := r.NextInt()
	for t > 0 {
		t--
		n := r.NextInt()
		latin := make(map[uint8]int32, 26)

		for i := uint8('a'); i <= uint8('z'); i++ {
			latin[i] = 0
		}

		for i := 0; i < n; i++ {
			j := r.NextInt()
			// fmt.Println(fmt.Sprintf("get j: %v", j))
			var tmp uint8
			for k, v := range latin {
				if int(v) == j {
					latin[k]++
					tmp = k
					break
				}
			}
			fmt.Print(string(tmp))
		}
		fmt.Println()
	}
}
func CF1927A() {
	r := NewR(bufio.NewReader(os.Stdin))
	t := r.NextInt()
	for t > 0 {
		t--
		n := r.NextInt()
		s := r.NextString()
		l, r := -1, -1
		for i := 0; i < n; i++ {
			if s[i] == 'B' {
				if l == -1 {
					l = i
					r = l + 1
				} else {
					r = i + 1
				}
			}
		}
		fmt.Println(r - l)
	}
}
func CF1728D() {
	r := NewR(bufio.NewReader(os.Stdin))
	t := r.NextInt()
	for t > 0 {
		t--
		s := r.NextString()
		i, j := 0, len(s)-1
		res := "Draw"
		for i < j {
			if s[i] != s[j] {
				res = "Alice"
				break
			}
			i++
			j--
		}
		if res == "Alice" {
			for ; i < j; i += 2 {
				if s[i] != s[i+1] {
					break
				}
			}
			if i > j {
				res = "Draw"
			}
		}
		fmt.Println(res)
	}
}
func CF1728C() {
	r := NewR(bufio.NewReader(os.Stdin))
	f := func(x int) int {
		if x > 99999999 {
			return 9
		} else if x > 9999999 {
			return 8
		} else if x > 999999 {
			return 7
		} else if x > 99999 {
			return 6
		} else if x > 9999 {
			return 5
		} else if x > 999 {
			return 4
		} else if x > 99 {
			return 3
		} else if x > 9 {
			return 2
		} else {
			return x
		}
	}
	t := r.NextInt()
	for t > 0 {
		t--
		n := r.NextInt()
		am := make(map[int]int, n)
		bm := make(map[int]int, n)
		for i := 0; i < n; i++ {
			tmp := r.NextInt()
			am[tmp]++
		}
		for i := 0; i < n; i++ {
			tmp := r.NextInt()
			if v, ok := am[tmp]; ok {
				if v > 0 {
					am[tmp]--
					if am[tmp] == 0 {
						delete(am, tmp)
					}
					continue
				}
			}
			bm[tmp]++
		}
		res := 0
		for k, v := range am {
			if k > 9 {
				delete(am, k)
				res += v
				k = f(k)
				am[k] += v
			}
			if vb, ok := bm[k]; ok {
				if v < vb {
					delete(am, k)
					bm[k] -= v
				} else if v > vb {
					delete(bm, k)
					am[k] -= vb
				} else {
					delete(am, k)
					delete(bm, k)
				}
			}
		}

		for k, v := range bm {
			if k > 9 {
				delete(bm, k)
				res += v
				k = f(k)
				bm[k] += v
			}
			if va, ok := am[k]; ok {
				if v < va {
					delete(bm, k)
					am[k] -= v
				} else if v > va {
					delete(am, k)
					bm[k] -= va
				} else {
					delete(am, k)
					delete(bm, k)
				}
			}
		}

		for k, v := range am {
			if k > 1 {
				res += v
			}
		}
		for k, v := range bm {
			if k > 1 {
				res += v
			}
		}
		fmt.Println(res)
	}
}
func CF1728B() {
	var t int
	fmt.Scan(&t)
	for i := 0; i < t; i++ {
		var n int
		fmt.Scan(&n)
		for j := 1; j <= n; j++ {
			if n&1 == 0 {
				if j < n-1 {
					if j&1 == 0 {
						fmt.Print(j - 1)
					} else {
						fmt.Print(j + 1)
					}
				} else {
					fmt.Print(j)
				}
			} else {
				if j == 1 || j >= n-1 {
					fmt.Print(j)
				} else {
					if j&1 == 0 {
						fmt.Print(j + 1)
					} else {
						fmt.Print(j - 1)
					}
				}
			}
			if j == n {
				fmt.Println("")
			} else {
				fmt.Print(" ")
			}
		}
	}
}
func CF1728A() {
	var t int
	fmt.Scan(&t)
	for t != 0 {
		t--
		var n int
		fmt.Scan(&n)
		var m int
		var mi int
		var i int = 1
		for n != 0 {
			n--
			var ai int
			fmt.Scan(&ai)
			if ai > m {
				m = ai
				mi = i
			}
			i++
		}
		fmt.Println(mi)
	}
}
