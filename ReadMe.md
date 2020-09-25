## Docker
* ```sudo docker build . -t omorfias```
* ```sudo docker run -it --rm -p 5001:5001 omorfias```
  * https://localhost:5001/swagger/index.html
* Full Command
  * ```sudo docker build . -t omorfias && sudo docker run -it --rm -p 5001:5001 omorfias```
* Link Heroku
  * http://omorfias.herokuapp.com/swagger/index.html
* Deploy heroku
  * heroku login
  * heroku container:login
  * sudo heroku container:push web -a omorfias
  * Deploy changes
    * heroku container:release web -a omorfias