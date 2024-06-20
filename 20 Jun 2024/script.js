
var userdetails = [
    {
        usermail : 'ratantata@gmail.com',
        userpassword : 'ratan123'
    },
    { usermail : 'markzuckerberg@gmail.com',
        userpassword :'mark123'},
    { usermail : 'elonmusk@gmail.com',
        userpassword :'elon123'}
];
document.getElementById('btn').addEventListener('click',()=>{
    var usermail = document.getElementById('usermail').value;
    console.log(usermail);
    var userpassword = document.getElementById('userpassword').value;
    userdetails.forEach((userdetail) => {
        if(userdetail.usermail === usermail && userdetail.userpassword === userpassword){
            document.getElementById('demo').innerHTML = 'User Logged In';
        }
    })
});
