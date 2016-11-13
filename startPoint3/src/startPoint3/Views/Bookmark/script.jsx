class Link extends React.Component {
    render() {
        return (<li className="bookMarkLi">
                  <a className="bookmarkLink" href={this.props.link.link}>
                    <img src={this.props.link.imgurl} width='75' height='75' />
                    <div>{this.props.link.name}</div>
                  </a>
                </li>
        );
    }
}

class LinkSection extends React.Component {
    render() {
    
        const linksToRender = this.props.section.links.map((linkA,index) =>
            <Link key={'link_' + this.props.sectionIndex + index} link={linkA} />
         );
    
                return (<div className="container">
                          <h3>{this.props.section.name}</h3>
                          <ul className="row">
                          {linksToRender}
                          </ul>
                        </div>
            );
            }
}

class Links extends React.Component {
  
    constructor(props) {
        super(props);
        this.state =getLinkData();
    };
  
    render() {
  
        const sections = this.state.sections.map((sectionA,index) =>
            <LinkSection key={'section_' + index} section={sectionA} sectionIndex={index} />
         );
   
   
  
                return (<div className="container body-content">
                          {sections}
                        </div>
            );
            }
}

function getLinkData()
{
  
    return  {
        "sections": [{
            "name": "A is a nice section name",
            "links": [{
                "name": "A1 link",
                "linkUrl": "http://www.itsajten.se/",
                "imgurl": "http://www.itsajten.se/tpl/default/img/favicon-144px.png"
            }, {
                "name": "A2 link",
                "linkUrl": "http://www.itsajten.se/",
                "imgurl": "http://www.itsajten.se/tpl/default/img/favicon-144px.png"
            }]
        }, {
            "name": "B is also good",
            "links": [{
                "name": "B link",
                "linkUrl": "http://www.itsajten.se/",
                "imgurl": "http://www.itsajten.se/tpl/default/img/favicon-144px.png"
            }, {
                "name": "A link",
                "linkUrl": "http://www.itsajten.se/",
                "imgurl": "http://www.itsajten.se/tpl/default/img/favicon-144px.png"
            },
            {
                "name": "Number 3 link",
                "linkUrl": "http://www.itsajten.se/",
                "imgurl": "http://www.itsajten.se/tpl/default/img/favicon-144px.png"
            }]
        },
        {
            "name": "Added another B section",
            "links": [{
                "name": "B link",
                "linkUrl": "http://www.itsajten.se/",
                "imgurl": "http://www.itsajten.se/tpl/default/img/favicon-144px.png"
            }, {
                "name": "A link",
                "linkUrl": "http://www.itsajten.se/",
                "imgurl": "http://www.itsajten.se/tpl/default/img/favicon-144px.png"
            },
            {
                "name": "Number 3 link",
                "linkUrl": "http://www.itsajten.se/",
                "imgurl": "http://www.itsajten.se/tpl/default/img/favicon-144px.png"
            }]
        }]
    }
  
}