﻿namespace Bluehill.Hangul.Tests;

public sealed class HangulCharTest {
    static readonly HangulChar gaChar = new('가');
    static readonly HangulChar hitChar = new('힣');

    [Fact]
    public void ConstructorTest1() {
        Assert.Throws<ArgumentException>("c", () => new HangulChar('e'));
    }

    [Fact]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Blocker Code Smell", "S2699:Tests should include assertions", Justification = "Not Needed")]
    public void ConstructorTest2() {
        _ = new HangulChar(Choseong.Giyeok, Jungseong.A, Jongseong.None);
    }

    [Fact]
    public void ConstructorTest3() {
        _ = new HangulChar(1, 2, 3);
        Assert.Throws<ArgumentOutOfRangeException>("choseong", () => new HangulChar(19, 0, 0));
        Assert.Throws<ArgumentOutOfRangeException>("jungseong", () => new HangulChar(0, 21, 0));
        Assert.Throws<ArgumentOutOfRangeException>("jongseong", () => new HangulChar(0, 0, 28));
    }

    [Fact]
    public void ConstructorTest4() {
        _ = new HangulChar('ㄱ', 'ㅏ', 'ㅎ');
        Assert.Throws<ArgumentException>("choseong", () => new HangulChar('ㅐ', 'ㅏ', 'ㅎ'));
        Assert.Throws<ArgumentException>("jungseong", () => new HangulChar('ㄱ', 'ㄴ', 'ㅎ'));
        Assert.Throws<ArgumentException>("jongseong", () => new HangulChar('ㄱ', 'ㅏ', 'ㅛ'));
    }

    [Fact]
    public void ChoseongTest() {
        Assert.Equal(Choseong.Giyeok, HangulChar.MinValue.Choseong);
        Assert.Throws<InvalidOperationException>(() => default(HangulChar).Choseong);
    }

    [Fact]
    public void JungseongTest() {
        Assert.Equal(Jungseong.A, HangulChar.MinValue.Jungseong);
        Assert.Throws<InvalidOperationException>(() => default(HangulChar).Jungseong);
    }

    [Fact]
    public void JongseongTest() {
        Assert.Equal(Jongseong.None, HangulChar.MinValue.Jongseong);
        Assert.Throws<InvalidOperationException>(() => default(HangulChar).Jongseong);
    }

    [Fact]
    public void ExplicitOperatorTest() {
        _ = (HangulChar)'가';
        Assert.Throws<ArgumentException>("c", () => (HangulChar)'s');
    }

    [Fact]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Blocker Code Smell", "S2699:Tests should include assertions", Justification = "Not Needed")]
    public void ImplicitOperatorTest() {
        _ = (char)gaChar;
    }

    [Fact]
    public void EqualityOperatorTest() {
        Assert.True(gaChar == HangulChar.MinValue);
        Assert.False(gaChar == HangulChar.MaxValue);
        Assert.False(hitChar == HangulChar.MinValue);
        Assert.True(hitChar == HangulChar.MaxValue);
    }

    [Fact]
    public void InequalityOperatorTest() {
        Assert.False(gaChar != HangulChar.MinValue);
        Assert.True(gaChar != HangulChar.MaxValue);
        Assert.True(hitChar != HangulChar.MinValue);
        Assert.False(hitChar != HangulChar.MaxValue);
    }

    [Fact]
    public void LessThanOperatorTest() {
        Assert.False(gaChar < HangulChar.MinValue);
        Assert.True(gaChar < HangulChar.MaxValue);
        Assert.False(hitChar < HangulChar.MinValue);
        Assert.False(hitChar < HangulChar.MaxValue);
    }

    [Fact]
    public void LessThanOrEqualOperatorTest() {
        Assert.True(gaChar <= HangulChar.MinValue);
        Assert.True(gaChar <= HangulChar.MaxValue);
        Assert.False(hitChar <= HangulChar.MinValue);
        Assert.True(hitChar <= HangulChar.MaxValue);
    }

    [Fact]
    public void GreaterThanOperatorTest() {
        Assert.False(gaChar > HangulChar.MinValue);
        Assert.False(gaChar > HangulChar.MaxValue);
        Assert.True(hitChar > HangulChar.MinValue);
        Assert.False(hitChar > HangulChar.MaxValue);
    }

    [Fact]
    public void GreaterThanOrEqualOperatorTest() {
        Assert.True(gaChar >= HangulChar.MinValue);
        Assert.False(gaChar >= HangulChar.MaxValue);
        Assert.True(hitChar >= HangulChar.MinValue);
        Assert.True(hitChar >= HangulChar.MaxValue);
    }

    [Fact]
    public void ToStringTest() {
        Assert.Equal("가", HangulChar.MinValue.ToString());
    }

    [Fact]
    public void EqualsTest1() {
        Assert.True(gaChar.Equals(HangulChar.MinValue));
        Assert.False(gaChar.Equals(HangulChar.MaxValue));
    }

    [Fact]
    public void EqualsTest2() {
        Assert.True(gaChar.Equals((object)HangulChar.MinValue));
        Assert.False(gaChar.Equals((object)HangulChar.MaxValue));
        Assert.False(gaChar.Equals(HangulChar.MinValue.WrappedChar));
    }

    [Fact]
    public void GetHashCodeTest() {
        Assert.Equal(HangulChar.MinValue.GetHashCode(), gaChar.GetHashCode());
        Assert.Equal(gaChar.WrappedChar.GetHashCode(), gaChar.GetHashCode());
    }

    [Fact]
    public void DeconstructTest() {
        var (choseong, jungseong, jongseong) = hitChar;

        Assert.Equal(Choseong.Hieut, choseong);
        Assert.Equal(Jungseong.I, jungseong);
        Assert.Equal(Jongseong.Hieut, jongseong);
    }
}