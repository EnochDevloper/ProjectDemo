//数组对象处理相关方法
Array.prototype.del = function (n) {//n表示第几项，从0开始算起。
    //prototype为对象原型，注意这里为对象增加自定义方法的方法。
    if (n < 0)//如果n<0，则不进行任何操作。
        return this;
    else
        return this.slice(0, n).concat(this.slice(n + 1, this.length));
    /*
　　　concat方法：返回一个新数组，这个新数组是由两个或更多数组组合而成的。
　　　　　　　　　这里就是返回this.slice(0,n)/this.slice(n+1,this.length)
　　 　　　　　　组成的新数组，这中间，刚好少了第n项。
　　　slice方法： 返回一个数组的一段，两个参数，分别指定开始和结束的位置。
　　*/
}
Array.prototype.indexOf = function (Object) {
    for (var i = 0; i < this.length; i++) {
        if (this[i] == Object) {
            return i;
        }
    }
    return -1;
}
Array.prototype.OrderByDesc = function (func) {
    var m = {};
    for (var i = 0; i < this.length; i++) {
        for (var k = 0; k < this.length; k++) {
            if (func(this[i]) > func(this[k])) {
                m = this[k];
                this[k] = this[i];
                this[i] = m;
            }
        }
    }
    return this;
}
Array.prototype.OrderDesc = function (propertyname) {
    var m = {};
    for (var i = 0; i < this.length; i++) {
        for (var k = 0; k < this.length; k++) {
            if ((this[i][propertyname]) > (this[k][propertyname])) {
                m = this[k];
                this[k] = this[i];
                this[i] = m;
            }
        }
    }
    return this;
}
Array.prototype.OrderAsc = function (propertyname) {
    var m = {};
    for (var i = 0; i < this.length; i++) {
        for (var k = 0; k < this.length; k++) {
            if ((this[i][propertyname]) < (this[k][propertyname])) {
                m = this[k];
                this[k] = this[i];
                this[i] = m;
            }
        }
    }
    return this;
}
Array.prototype.Where = function (p, t, v) {
    var a = new Array();
    if (t == "!=") {
        for (var i = 0; i < this.length; i++) {
            if (this[i][p] != v) {
                a.push(this[i]);
            }
        }
    } else if (t == "=") {
        for (var i = 0; i < this.length; i++) {
            if (this[i][p] == v) {
                a.push(this[i]);
            }
        }
    }
    else if (t == "in") {
        var valArral = v.split(",");
        for (var j = 0; j < valArral.length; j++) {
            for (var i = 0; i < this.length; i++) {
                if (this[i][p] == valArral[j]) {
                    a.push(this[i]);
                }
            }
        }
        
    }
    else if (t == ">") {
        for (var i = 0; i < this.length; i++) {
            if (this[i][p] > v) {
                a.push(this[i]);
            }
        }
    }
    else if (t == "<") {
        for (var i = 0; i < this.length; i++) {
            if (this[i][p] < v) {
                a.push(this[i]);
            }
        }
    }
    else if (t == "<=") {
        for (var i = 0; i < this.length; i++) {
            if (this[i][p] <= v) {
                a.push(this[i]);
            }
        }
    }
    else if (t == ">=") {
        for (var i = 0; i < this.length; i++) {
            if (this[i][p] >= v) {
                a.push(this[i]);
            }
        }
    }
    return a;
}
Array.prototype.Distinct = function () {
    var ArrayObj = {};
    var returnArray = [];
    for (var i = 0; i < this.length; i++) {
        if (ArrayObj[this[i]]) continue;
        ArrayObj[this[i]] = this[i];
        returnArray.push(this[i]);
    }
    return returnArray;
}
Array.prototype.FirstOrDefault = function () {
    if (this.length > 0) {
        return this[0];
    }
    else {
        return null;
    }
}
Array.prototype.FindFirst = function (p, t, v) {

    if (t == "!=") {
        for (var i = 0; i < this.length; i++) {
            if (this[i][p] != v) {
                return this[i];
            }
        }
    } else if (t == "=") {
        for (var i = 0; i < this.length; i++) {
            if (this[i][p] == v) {
                return this[i];
            }
        }
    }
    else if (t == ">") {
        for (var i = 0; i < this.length; i++) {
            if (this[i][p] > v) {
                return this[i];
            }
        }
    }
    else if (t == "<") {
        for (var i = 0; i < this.length; i++) {
            if (this[i][p] < v) {
                return this[i];
            }
        }
    }
    else if (t == "<=") {
        for (var i = 0; i < this.length; i++) {
            if (this[i][p] <= v) {
                return this[i];
            }
        }
    }
    else if (t == ">=") {
        for (var i = 0; i < this.length; i++) {
            if (this[i][p] >= v) {
                return this[i];
            }
        }
    }
    return null;
}
Array.prototype.delItem = function (p, v) {
    var n;
    var a = [];
    for (var i = 0; i < this.length; i++) {
        if (this[i][p] == v) {
            n = i;
            break;
        }
    }
    if (n != undefined) {
        a = this.del(n);
        return a;
    }
    else {
        return this;
    }
}
///把数据一分为二 返回对象{a:any[],b:any[]}的对象
///如果为不够均分,则b数组末尾元素为null
Array.prototype.splitArrayToTwo = function splitArrayToTwo() {
    var a = this;
    var ret = { a: [], b: [] };
    for (var i = 0; i < a.length; i++) {
        if (i % 2 == 0) {
            ret.a.push(a[i]);
        }
        else {
            ret.b.push(a[i]);
        }
    }
    if (a.length % 2 !== 0) {
        ret.b.push(null);
    }
    return ret;
}

Array.prototype.sum = function (p) {
    var s = 0.00;
    for (var i = 0; i < this.length; i++) {
        s += this[i][p];
    }
    return s;
}




$(function () {
    setTimeout(hidePawnGroup, 3000);
})

function hidePawnGroup() {
    var pawnbody = $("#tbody-pawn");
    if ($("#tbody-pawn").length > 0) {
        $("#tbody-pawn").parent().find("th").eq(2).hide();
        $("#tbody-pawn tr").each(function () {
            $(this).find("td").eq(2).hide();
        })
    }
}