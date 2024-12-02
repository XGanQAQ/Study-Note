要把局域网服务器公开到公网，在只有局域网服务器可以访问公网服务器的情况下，可以使用「反向代理」或「内网穿透」的方式实现。以下是几种常见的方法：

### 方法1：反向代理 + SSH隧道
这种方法需要在局域网服务器和公网服务器之间创建一个隧道，使公网服务器可以通过该隧道访问局域网服务器的服务。

1. **在局域网服务器上创建SSH隧道：**
   - 在局域网服务器上执行以下命令，创建反向隧道，将局域网服务器的端口映射到公网服务器上。
   ```bash
   ssh -R 公网服务器端口:localhost:局域网服务器端口 用户名@公网服务器IP
   ```
   - 示例：假设局域网服务器在本地监听80端口，公网服务器使用8080端口来访问局域网服务器，则执行以下命令：
   ```bash
   ssh -R 8080:localhost:80 用户名@公网服务器IP
   ```

2. **在公网服务器上配置反向代理（可选）：**
   - 使用Nginx或Apache等反向代理服务器，将8080端口的流量代理到局域网服务器的隧道上。
   - 配置Nginx示例：
   ```nginx
   server {
       listen 80;
       server_name 公网服务器域名;

       location / {
           proxy_pass http://localhost:8080;
           proxy_set_header Host $host;
           proxy_set_header X-Real-IP $remote_addr;
           proxy_set_header X-Forwarded-For $proxy_add_x_forwarded_for;
           proxy_set_header X-Forwarded-Proto $scheme;
       }
   }
   ```

3. **访问测试：**
   - 配置完成后，在浏览器中访问公网服务器的域名或IP地址，可以看到局域网服务器的内容。

### 方法2：使用内网穿透工具
如果需要长期公开且需要更高的稳定性，可以考虑使用内网穿透工具，例如：[ngrok](https://ngrok.com/)、[FRP](https://github.com/fatedier/frp) 或 [NPS](https://github.com/ehang-io/nps)。

#### 以FRP为例：
1. **安装FRP：**
   - 在公网服务器上部署FRP服务端，在局域网服务器上部署FRP客户端。

2. **配置FRP：**
   - 配置公网服务器的FRP服务端`frps.ini`：
     ```ini
     [common]
     bind_port = 7000
     ```

   - 配置局域网服务器的FRP客户端`frpc.ini`：
     ```ini
     [common]
     server_addr = 公网服务器IP
     server_port = 7000

     [web]
     type = http
     local_port = 局域网服务器端口
     custom_domains = 公网服务器域名
     ```

3. **启动FRP：**
   - 分别启动FRP服务端和客户端。

4. **访问测试：**
   - 在浏览器中通过公网服务器的域名或IP地址访问局域网服务器的内容。

这两种方法都可以将局域网服务器公开到公网，如果你只需要一个稳定的映射，推荐第二种方法，因为FRP等内网穿透工具更适合长期使用，并且管理配置更加方便。