#### 页面配置问题

**https://comm100corp-my.sharepoint.com/:o:/g/personal/lei_zhang_comm100_com/En78TB0Jh5RGqOdqLs3pdMEBPmYF6BIUqzIzIDVs4k-K5Q**

#### 写后端API接口

Event如果是自己写的，就要写Event，EventService，还要在GlobalDomainService里面注册

![image-20210827133832138](C:\Users\Com100\AppData\Roaming\Typora\typora-user-images\image-20210827133832138.png)

#### C#enum,string,int直接的相互转换

https://www.cnblogs.com/pato/archive/2011/08/15/2139705.html

# 关于Linq:如何使用lambda表达式查询嵌套列表

https://www.codenong.com/1627170/



string的contains比较忽略大小写：stringArray.Contains("A", StringComparer.OrdinalIgnoreCase);



#### 关于List判断是否有重复项：

https://blog.csdn.net/weixin_30390075/article/details/95823895

#### 显示接口实现与隐式接口实现的适应场景

1. 当类实现一个接口时，通常使用隐式接口实现，这样可以方便的访问接口方法和类自身具有的方法和属性。
2. 当类实现多个接口时，并且接口中包含相同的方法签名，此时使用显式接口实现。即使没有相同的方法签名，仍推荐使用显式接口，因为可以标识出哪个方法属于哪个接口。
3. 隐式接口实现，类和接口都可访问接口中方法。显式接口实现，只能通过接口访问。





### partner外网环境

[14:56] Frank Feng partner:
https://partner4partner.testing.comm100dev.io/     hardy.song@comm100.com 111111 (partner10000)
 Control panel:
https://partner4dash.testing.comm100dev.io/login/ bella@0901.com 111111 Comm100



[The CICD pipeline WAN environment K8S Dashboard](https://k8stestingnew.comm100dev.io/) 
**AccessToken:**
`eyJhbGciOiJSUzI1NiIsImtpZCI6IjJjaVlKSFhFTFZpQm8wN2Y4TURoTDg5cWhmTmctWlY0MHJUWDBLSXhoVG8ifQ.eyJpc3MiOiJrdWJlcm5ldGVzL3NlcnZpY2VhY2NvdW50Iiwia3ViZXJuZXRlcy5pby9zZXJ2aWNlYWNjb3VudC9uYW1lc3BhY2UiOiJrdWJlcm5ldGVzLWRhc2hib2FyZCIsImt1YmVybmV0ZXMuaW8vc2VydmljZWFjY291bnQvc2VjcmV0Lm5hbWUiOiJhdXRvY29kaW5nLXRva2VuLXJrbHJzIiwia3ViZXJuZXRlcy5pby9zZXJ2aWNlYWNjb3VudC9zZXJ2aWNlLWFjY291bnQubmFtZSI6ImF1dG9jb2RpbmciLCJrdWJlcm5ldGVzLmlvL3NlcnZpY2VhY2NvdW50L3NlcnZpY2UtYWNjb3VudC51aWQiOiIyMDRhNjIwZS0xNjM2LTQ4NzktOWM5NS02MWQ2ZmI5M2YzMjMiLCJzdWIiOiJzeXN0ZW06c2VydmljZWFjY291bnQ6a3ViZXJuZXRlcy1kYXNoYm9hcmQ6YXV0b2NvZGluZyJ9.oDMqB60V-jp-WRcJJ2LoWQGsHMt_K7uQj6orFJPv7631Nb3d7JQNLQG-hcpDt7xKOIaZ-ztiPlt1kjWwXoZwBkeiLNPK8E_q9Z7Q_9jBbOhC_3zBnJbEyFfrv5T70-6e65b9SDgmV4O2sj4Ydn0Eb0WmFy2q54wLUpczIND_tUqpuAVTBo7D9k5f6bzJ3gNPXOtU8xF4wOhWGAehHGYcLBfIFl8ax6-1zu5y9zF9EA9P6SXsifseB38jmce2JbeJyy76dj-uTFtZT9zAbo53mUYaYcEJb9aQSE9ZYxjTMvr_54auHA4Xqpv1WbTTjM9qvg1QnyXsEMDsgJ9t7TR7BQ`



#### 事物的隔离级别

https://developer.aliyun.com/article/743691



#### 路径问题：

1、一个点：表示当前目录。即类似使用：./juqery.min.js。 
2、两个点：表示当前目录的上级目录。类似：`<script type="text/javascript" src="../jquery.easyui.min.js"></script>`



#### C# ? ?? ?:的区别

1、可空类型修饰符（?）

int? a = null;
2、空合并运算符(??)

   用于定义可空类型和引用类型的默认值。如果此运算符的左操作数不为null，则此运算符将返回左操作数，否则返回右操作数。
    例如：a ?? b 当a为null时则返回b，a不为null时则返回a本身。

string a = null;
string b = "b";
string c = "c";
var d = a ?? b ?? c; //"b"
3、三元（运算符）表达式（?:)

  x?y:z 表示如果表达式x为true，则返回y；如果x为false，则返回z，是省略if{}else{}的简单形式。

string a = "a";
var b = a == "a" ? "a" : "b"; //"a"
4、具体使用案例：在不报异常的情况下取为null的lst中集合的个数

List<string> lst = null;
var a = lst?.Count ?? 0; //0
var b = lst == null ? 0 : lst.Count; //0



#### ASP.net core MVC 视频

https://www.bilibili.com/video/BV18h411879a?from=search&seid=7569903881492011282&spm_id_from=333.337.0.0



https://www.bilibili.com/video/BV1wb411W7aB?p=8&spm_id_from=pageDriver

