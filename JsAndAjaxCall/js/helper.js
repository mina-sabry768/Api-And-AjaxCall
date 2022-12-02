let Helper ={
    AjaxCallGet:(Url, success, error)=>{
        $.ajax({
            url: Url,
            method:"GET",
            cache:false,
            success:(data)=>{
                success(data);
                return data;
            },
            error:(err)=>{
                error(err);
                return 0;
            }
        });
    },
    AjaxCallPost:(Url, paramters,success,error)=>{
        $.ajax({
            url:Url,
            method:'POST',
            contentType:"application/json",
            data:paramters,
            cache:false,
            success:(data)=>{
                success(data);
                return data;
            },
            error:(err)=>{
                error(err);
                return 0;
            }
            
        });
    },
    AjaxCallPut:(Url, paramters,success,error)=>{
        $.ajax({
            url:Url,
            method:'PUT',
            contentType:"application/json",
            data:paramters,
            cache:false,
            success:(data)=>{
                success(data);
                return data;
            },
            error:(err)=>{
                error(err);
                return 0;
            }
            
        });
    },
    AjaxCallDelete:(Url, success, error)=>{
        $.ajax({
            url: Url,
            method:"DELETE",
            cache:false,
            success:(data)=>{
                success(data);
                return data;
            },
            error:(err)=>{
                error(err);
                return 0;
            }
        });
    },
};