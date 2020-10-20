<%@ Page Title="About Us" Language="C#" MasterPageFile="~/masterPage.Master" AutoEventWireup="true" CodeBehind="About.aspx.cs" Inherits="manhua.About" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        p{
            text-align:left;
        }
        h3{
            text-align:left;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="main" runat="server">
    <div class="banner">
        <div class="container">
            <div class="banner-text">
                <div class="banner-heading">
                    Welcome to コミック 
                </div>
                <div class="banner-sub-heading">
                 There are a lot of good-looking comics waiting for you to see
                </div>
                
                    <asp:Button ID="button" class="btn btn-warning text-dark btn-banner" runat="server" Text="Get Started" OnClick="button_Click" />
                
            </div>
        </div>
    </div>
    <section id="about">
        <div class="container">
            <div class="text-intro">
                <h1>Why Read Manga on コミック ?</h1>
                <img src="/pic/background_image/mangazuki-manga-1024x430.jpg" width="1024px" height="430px"/>
                <p>コミック  is a place created by the fans, Created for the fans. It’s a place where you can read high quality manga online absolutely free. Here you can Read manga online like no other. This website has been made specifically for manga lovers who want to read all kinds of manga online, manhwa and even manhua.</p>
                <p>Team コミック  aims to provide great quality manga related content to of people of all ages. The idea is to spread love for manga and share it with people all around the world so they can enjoy manga online. We believe that the amazing stories in different manga need to be shared with the world. With that in mind, we created コミック  and decided to make it free for everyone.</p>     
                <h3>What makes manga so Special?</h3>
                <p>There’s something very specific about manga, it’s a super combo of artwork and textual content. It’s wonderful storystyle makes it ideal manner to portray lives of different human beings as well as characters. but many people are unable to study manga because they don’t need to shop for it, they want so that you can read it on line without spending a dime and there’s wherein mangazuki comes in. Our concept is precisely to offer the lovers what they want. We need you in an effort to read manga on-line without any cost.</p>
                <p>We need to build a platform that anyone can get entry to and read manga in high fine. we’ve attempted our fine to feature as many genres as we will, in the intervening time we’re including some selective manga that we accept as true with our readers will experience however as we develop. we can be adding plenty more manga inside the destiny at mangazuki. So, we anticipate our readers to be patient and read the manhwa/manhua/anga we’ve introduced. We want to keep the satisfactory up to speed so we will be adding high excellent manga at the internet site even as preserving the loading velocity as speedy as feasible.</p>
               <p>We accept as true with that Manga is greater than simply comic and studying manga deliver splendid pleasure. It’s a medium of expression and over time, it has grow to be an art. The idea that one mangaka can inspire tens of millions of people round the arena feels almost magical. We at Mangazuki need to help the human beings and unfold their message.</p>
            <h3>Our little effort to make the experience better</h3>    
                <p>コミック is our little effort to make the manga and anime community a little more accessible so that everyone can read manga free. We believe in the freedom of reading manga and that drives us to pursue our goal of spreading love for manga in the world.</p>
            <p>we’ve got high hopes that humans will come and experience this vicinity, our handpicked manga collection is for absolutely everyone that wants to examine even manhwa or manhua for  free. We include manga for every age so don’t stardle if you locate something 18+.</p>
               <p>Other than our top rate phase most of the manga on コミック is and will always be free however we will show ads, I mean we do have to pay our payments right? So we are hoping you experience it slow here and become a part of our little on line manga mission.
help us by way of sharing this website along with your friends! also don’t overlook the bookmark us so you can study manga on line. We’ve got made the website in manner that it’s very easy to use. We made all the sections as simple as feasible.</p>
                <p>You may bookmark any bankruptcy you need and read later with the aid of signing up. you could additionally, seek up any manga you need effortlessly using the search bar.</p>
                </div>
        </div>
    </section>
    <style>

        .banner {
            background-image: url('http://www.hd-freewallpapers.com/latest-wallpapers/abstract-website-backgrounds.jpg');
            text-align: center;
            color: #fff;
            background-repeat: no-repeat;
            background-attachment: scroll;
            background-position: center center;
            -webkit-background-size: cover;
            -moz-background-size: cover;
            -o-background-size: cover;
            background-size: cover;
        }

        .banner-text {
            padding: 200px 0 150px 0;
        }

        .banner-heading {
            font-family: 'Lobster', cursive;
            font-size: 75px;
            font-weight: 700;
            line-height: 100px;
            margin-bottom: 30px;
            color: #fff;
        }

        .banner-sub-heading {
            font-family: 'Libre Baskerville', serif;
            font-size: 30px;
            font-weight: 300;
            line-height: 30px;
            margin-bottom: 50px;
            color: #fff;
        }

        .btn-banner {
            padding: 5px 20px;
            border-radius: 10px;
            font-weight: 700;
            line-height: 1.5;
            text-align: center;
            color: #fff;
            text-transform: uppercase;
        }

        .text-intro {
            width: 90%;
            margin: auto;
            text-align: center;
            padding-top: 30px;
        }
        @media (max-width:500px) {
            

            .banner-text {
                padding: 150px 0 150px 0;
            }

            .banner-heading {
                font-size: 30px;
                line-height: 30px;
                margin-bottom: 20px;
            }

            .banner-sub-heading {
                font-size: 10px;
                font-weight: 200;
                line-height: 10px;
                margin-bottom: 40px;
            }
        }

        @media (max-width:768px) {
            .banner-text {
                padding: 150px 0 150px 0;
            }

            .banner-sub-heading {
                font-size: 23px;
                font-weight: 200;
                line-height: 23px;
                margin-bottom: 40px;
            }
        }
    </style>
</asp:Content>
