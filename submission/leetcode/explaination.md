# LeetCode Problem Solving Summary
# Account Link : https://leetcode.com/u/Asemo505/
## Solutions Overview

| # | Problem Title | Difficulty | Approach | Time Complexity | Space Complexity |
|---|---|---|---|---|---|
| 242 | [Valid Anagram](https://leetcode.com/problems/valid-anagram/) | Easy | Frequency Array | $O(N)$ | $O(1)$ |
| 1071 | [Greatest Common Divisor of Strings](https://leetcode.com/problems/greatest-common-divisor-of-strings/) | Easy | Concatenation Check & GCD | $O(N + M)$ | $O(N + M)$ |

---

## Explanations

### 1. Valid Anagram (LeetCode 242)
* **Goal:** Determine if string `t` is an anagram of string `s` (contains the exact same characters with the exact same frequencies).
* **Approach:** Uses a fixed-size frequency array of length 26 to count occurrences. Increments count for characters in `s` and decrements for `t`. If all frequencies remain zero, the strings are anagrams.
* **Complexity:**
  * **Time:** $O(N)$ — Single pass over the strings.
  * **Space:** $O(1)$ — Fixed array size regardless of input.

---

### 2. Greatest Common Divisor of Strings (LeetCode 1071)
* **Goal:** Find the largest string `x` that can be repeatedly concatenated to form both `str1` and `str2`.
* **Approach:** Verifies string compatibility by checking if `str1 + str2 == str2 + str1`. If true, computes the Greatest Common Divisor (GCD) of their lengths to extract the largest repeating pattern prefix.
* **Complexity:**
  * **Time:** $O(N + M)$ — String concatenation and comparison.
  * **Space:** $O(N + M)$ — Temporary memory for string concatenation.