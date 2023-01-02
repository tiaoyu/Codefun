package main

import (
	"bufio"
	"fmt"
	"os"
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
	CF1728D()
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
