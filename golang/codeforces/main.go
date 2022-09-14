package main

import "fmt"

func main() {
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
