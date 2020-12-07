import java.util.Scanner;
import java.util.regex.Matcher;
import java.util.regex.Pattern;

public class mobile
{
  public static void main(String []args)
  {
  Scanner sc = new Scanner (System.in);
  System.out.println ("Enter mobile number for India or New Zealand:");
  String mob = sc.next(); 
// Regular expressions to accept Indian and New Zealand Mobile number 
  String regex1 = "\\d{10}";
  String regex2 = "\\d{9}";
// Creating a pattern object 
 Pattern p1 = Pattern.compile(regex1);
 Pattern p2 = Pattern.compile(regex2);
// Creating a matcher object
 Matcher m1 = p1.matcher(mob);
 Matcher m2 = p2.matcher(mob);
// verifying mobile number is Indian or New Zealand
  if (m1.matches())
  {
  System.out.println ("Valid Indian mobile number");
  }
  else if(m2.matches())
  {
 System.out.println ("Valid New Zealand mobile number");
  }
  else
  { 
 System.out.println ("Invalid mobile number");
  }
 }
}
 
