using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookRentalShop.Helpers
{
    internal class Commons
    {
        //static으로 선언하였기에 BookRentalShop 하위 모든 프로그램에서 사용 가능
        public static readonly string ConnString = "Server=localhost;"+
                                            "Port=3306;"+
                                            "Database=bookrentalShop;"+
                                            "Uid=root;"+
                                            "Pwd=12345";

        //로그인 사용자 아이디 저장변수
        //프로그램 전체에서 이 데이터를 공유
        public static string LoginID = string.Empty;
    }
}
