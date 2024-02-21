package main

import (
	"bufio"
	"fmt"
	"os"
)

// 求字符串中所有字串是否包含前k个字母且长度为n的所有排列组合
// 思路：
// 在字符串中依次统计前k个字母是否出现，每正好全部都出现过，则重新统计，且保存最后一个字母；
// 最后统计的数字大于等于n，则输出YES，否则输出NO，然后再保存未能组成一组的缺失的任一个字母，并且不足n长度用 'a' 补齐
func CF1921A() {
	r := NewR(bufio.NewReader(os.Stdin))
	t := r.NextInt()
	latin := "abcdefghijklmnopqrstuvwxyz"

	for t > 0 {
		t--
		n, k, m := r.NextInt(), r.NextInt(), r.NextInt()
		s := r.NextString()
		tmp := make(map[uint8]int)
		mlatin := make(map[uint8]struct{})
		for i := 0; i < k; i++ {
			mlatin[uint8(latin[i])] = struct{}{}
		}
		inx := 0
		ans := ""
		for i := 0; i < m; i++ {

			if s[i] <= uint8(latin[k-1]) {
				tmp[s[i]]++
			}
			if len(tmp) == k {
				tmp = make(map[uint8]int)
				inx++
				ans += string(s[i])
			}
		}

		if inx >= n {
			fmt.Println("YES")
		} else {
			for v := range tmp {
				delete(mlatin, v)
			}
			for v := range mlatin {
				ans += string(v)
				inx++
				break
			}
			for i := inx; i < n; i++ {
				ans += "a"
			}
			fmt.Println("NO")
			fmt.Println(ans)
		}
	}
}
